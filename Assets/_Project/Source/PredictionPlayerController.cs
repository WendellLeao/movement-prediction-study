using FishNet.Object.Prediction;
using FishNet.Transporting;
using FishNet.Utility.Template;
using GameKit.Dependencies.Utilities;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Project.Source
{
    internal sealed class PredictionPlayerController : TickNetworkBehaviour
    {
        [SerializeField]
        private Rigidbody rigidbody;
        [SerializeField]
        private float moveSpeed = 5f;
        
        private PredictionRigidbody _predictionRigidbody;
        private Vector3 _moveDirection;

        private void Awake()
        {
            _predictionRigidbody = ObjectCaches<PredictionRigidbody>.Retrieve();
            _predictionRigidbody.Initialize(rigidbody);
        }

        private void OnDestroy()
        {
            ObjectCaches<PredictionRigidbody>.StoreAndDefault(ref _predictionRigidbody);
        }

        private void Update()
        {
            if (!IsOwner)
            {
                return;
            }

            Keyboard keyboard = Keyboard.current;
            
            if (keyboard == null)
            {
                return;
            }

            _moveDirection = GetMoveDirection(keyboard).normalized;
        }

        protected override void TimeManager_OnTick()
        {
            base.TimeManager_OnTick();

            ReplicateData replicateData = CreateReplicateData();
            
            RunInputs(replicateData);
        }

        protected override void TimeManager_OnPostTick()
        {
            base.TimeManager_OnPostTick();
            
            CreateReconcile();
        }

        public override void CreateReconcile()
        {
            base.CreateReconcile();
            
            ReconcileData rd = new ReconcileData(_predictionRigidbody);
            
            ReconcileState(rd);
        }

        [Replicate]
        private void RunInputs(ReplicateData data, ReplicateState state = ReplicateState.Invalid, Channel channel = Channel.Unreliable)
        {
            Vector3 nextPosition = _predictionRigidbody.Rigidbody.position + data.moveDirection * (moveSpeed * (float)TimeManager.TickDelta);
            _predictionRigidbody.MovePosition(nextPosition);
            _predictionRigidbody.Simulate();
        }

        [Reconcile]
        private void ReconcileState(ReconcileData data, Channel channel = Channel.Unreliable)
        {
            _predictionRigidbody.Reconcile(data.predictionRigidbody);
        }
        
        private ReplicateData CreateReplicateData()
        {
            if (!IsOwner)
            {
                return default;
            }

            return new ReplicateData(_moveDirection);
        }

        private Vector3 GetMoveDirection(Keyboard keyboard)
        {
            Vector3 direction = Vector3.zero;

            if (keyboard.wKey.isPressed)
            {
                direction += Vector3.forward;
            }

            if (keyboard.aKey.isPressed)
            {
                direction += Vector3.left;
            }
            
            if (keyboard.sKey.isPressed)
            {
                direction += Vector3.back;
            }

            if (keyboard.dKey.isPressed)
            {
                direction += Vector3.right;
            }

            return direction;
        }
    }
}
