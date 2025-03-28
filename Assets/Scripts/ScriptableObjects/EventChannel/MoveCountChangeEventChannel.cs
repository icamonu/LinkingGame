using System;
using UnityEngine;

namespace ScriptableObjects.EventChannel
{
    [CreateAssetMenu(fileName = "MoveCountChangeEventChannel", menuName = "ScriptableObjects/MoveCountChangeEventChannel")]
    public class MoveCountChangeEventChannel: ScriptableObject
    {
        public event Action<int> OnMoveCountChanged;
        
        public void RaiseMoveCountChangedEvent(int moveCount)
        {
            OnMoveCountChanged?.Invoke(moveCount);
        }
    }
}