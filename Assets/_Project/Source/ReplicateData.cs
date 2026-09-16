using FishNet.Object.Prediction;
using UnityEngine;

namespace _Project.Source
{
    internal struct ReplicateData : IReplicateData
    {
        public Vector3 moveDirection;
        
        private uint _tick;

        public ReplicateData(Vector3 moveDirection) : this()
        {
            this.moveDirection = moveDirection;
        }

        public void Dispose()
        { }
        
        public uint GetTick()
        {
            return _tick;
        }

        public void SetTick(uint value)
        {
            _tick = value;
        }
    }
}
