using System;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects.EventChannel
{
    [CreateAssetMenu(fileName = "BoardFillEventChannel", menuName = "ScriptableObjects/BoardFillEventChannel", order = 0)]
    public class BoardFillEventChannel: ScriptableObject
    {
        public event Action<List<Vector2Int>> OnBoardFillOrder;
        public event Action OnBoardFillCompleted; 
        
        public void RaiseBoardFillOrderEvent(List<Vector2Int> emptyPositions)
        {
            OnBoardFillOrder?.Invoke(emptyPositions);
        }
        
        public void RaiseBoardFillCompletedEvent()
        {
            OnBoardFillCompleted?.Invoke();
        }
    }
}