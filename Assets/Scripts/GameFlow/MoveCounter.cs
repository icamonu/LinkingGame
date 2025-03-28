using ScriptableObjects.EventChannel;
using UnityEngine;

namespace GameFlow
{
    public class MoveCounter: MonoBehaviour
    {
        [SerializeField] private ChipCollectionEventChannel chipCollectionEventChannel;
        [SerializeField] private MoveCountChangeEventChannel moveCountChangeEventChannel;
        public int Moves { get; private set; }=0;
        
        private void OnEnable()
        {
            chipCollectionEventChannel.OnChipCollectionCompleted += OnChipCollection;
        }
        
        private void OnDisable()
        {
            chipCollectionEventChannel.OnChipCollectionCompleted -= OnChipCollection;
        }

        private void Start()
        {
            moveCountChangeEventChannel.RaiseMoveCountChangedEvent(0);
        }

        private void OnChipCollection()
        {
            Moves++;
            moveCountChangeEventChannel.RaiseMoveCountChangedEvent(Moves);
        }
    }
}