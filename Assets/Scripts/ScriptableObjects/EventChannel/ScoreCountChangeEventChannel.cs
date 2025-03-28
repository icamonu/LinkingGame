using System;
using UnityEngine;

namespace ScriptableObjects.EventChannel
{
    [CreateAssetMenu(fileName = "ScoreCountChangeEventChannel", menuName = "ScriptableObjects/ScoreCountChangeEventChannel")]
    public class ScoreCountChangeEventChannel: ScriptableObject
    {
        public event Action<int> OnScoreCountChanged;
        
        public void RaiseScoreCountChangedEvent(int scoreCount)
        {
            OnScoreCountChanged?.Invoke(scoreCount);
        }
    }
}