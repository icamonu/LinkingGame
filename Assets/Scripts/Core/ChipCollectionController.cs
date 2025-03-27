using System.Collections.Generic;
using Core.Data;
using ScriptableObjects;
using UnityEngine;

namespace Core
{
    public class ChipCollectionController: MonoBehaviour
    {
        [SerializeField] private BoardData _boardData;
        [SerializeField] private ChipCollectionEventChannel _chipCollectionEventChannel;
        
        private void OnEnable()
        {
            _chipCollectionEventChannel.OnChipCollection += OnChipCollection;
        }
        
        private void OnDisable()
        {
            _chipCollectionEventChannel.OnChipCollection -= OnChipCollection;
        }
        
        private void OnChipCollection(List<Vector2Int> collectedChips)
        {
            foreach (Vector2Int chip in collectedChips)
            {
                _boardData.Chips[chip].gameObject.SetActive(false);
                _boardData.SetChip(chip, null);
            }
        }
    }
}