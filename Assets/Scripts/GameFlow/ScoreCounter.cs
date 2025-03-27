using System;
using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;

namespace GameFlow
{
    public class ScoreCounter: MonoBehaviour
    {
        [SerializeField] private ChipCollectionEventChannel chipCollectionEventChannel;
        [SerializeField] private ScoreCountChangeEventChannel scoreCountChangeEventChannel;
        public int Score { get; private set; } = 0;
        
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
            Score += collectedChips.Count;
            scoreCountChangeEventChannel.RaiseScoreCountChangedEvent(Score);
        }
    }
}