using System;
using System.Collections.Generic;
using Core.Data;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "ChipCollectionEventChannel", menuName = "ScriptableObjects/ChipCollectionEventChannel")]
    public class ChipCollectionEventChannel: ScriptableObject
    {
        public event Action<List<Vector2Int>> OnChipCollection;
        public event Action OnChipCollectionCompleted;

        public void RaiseChipCollectionEvent(List<Vector2Int> chips)
        {
            OnChipCollection?.Invoke(chips);
        }
        
        public void RaiseChipCollectionCompletedEvent()
        {
            OnChipCollectionCompleted?.Invoke();
        }
    }
}