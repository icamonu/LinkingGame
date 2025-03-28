using System.Collections.Generic;
using Core.Data;
using ScriptableObjects.EventChannel;
using UnityEngine;

namespace Core
{
    public class ChipCollectionController: MonoBehaviour
    {
        [SerializeField] private BoardData boardData;
        [SerializeField] private ChipCollectionEventChannel chipCollectionEventChannel;
        
        private void OnEnable()
        {
            chipCollectionEventChannel.OnChipCollection += OnChipCollection;
        }
        
        private void OnDisable()
        {
            chipCollectionEventChannel.OnChipCollection -= OnChipCollection;
        }
        
        private void OnChipCollection(List<Vector2Int> collectedChips)
        {
            foreach (Vector2Int chip in collectedChips)
            {
                boardData.Chips[chip].OnCollected();
                boardData.SetChip(chip, null);
            }
            
            chipCollectionEventChannel.RaiseChipCollectionCompletedEvent();
        }
    }
}