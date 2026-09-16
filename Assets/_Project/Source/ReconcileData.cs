using FishNet.Object.Prediction;

namespace _Project.Source
{
    internal struct ReconcileData : IReconcileData
    {
        public PredictionRigidbody predictionRigidbody;
        
        private uint _tick;

        public ReconcileData(PredictionRigidbody pr) : this()
        {
            predictionRigidbody = pr;
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
