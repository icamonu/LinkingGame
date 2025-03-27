using System;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "BoardFillEventChannel", menuName = "ScriptableObjects/BoardFillEventChannel", order = 0)]
    public class BoardFillEventChannel: ScriptableObject
    {
        public event Action<List<Vector2Int>> OnBoardFillOrder;
        
        public void RaiseBoardFillOrderEvent(List<Vector2Int> order)
        {
            OnBoardFillOrder?.Invoke(order);
        }
    }
}