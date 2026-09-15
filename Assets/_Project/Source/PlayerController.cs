using FishNet.Object;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Project.Source
{
    internal sealed class PlayerController : NetworkBehaviour
    {
        [SerializeField] private float _moveSpeed = 5f;

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

            Vector3 direction = Vector3.zero;

            if (keyboard.wKey.isPressed)
            {
                direction += Vector3.forward;
            }

            if (keyboard.sKey.isPressed)
            {
                direction += Vector3.back;
            }

            if (keyboard.aKey.isPressed)
            {
                direction += Vector3.left;
            }

            if (keyboard.dKey.isPressed)
            {
                direction += Vector3.right;
            }

            transform.position += direction.normalized * (_moveSpeed * Time.deltaTime);
        }
    }
}
