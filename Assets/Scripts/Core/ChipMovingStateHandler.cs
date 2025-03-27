using Interfaces;
using DG.Tweening;
using UnityEngine;

namespace Core
{
    public class ChipMovingStateHandler: IStateHandler
    {
        private Transform _transform;
        private Vector3 _targetPosition;
        
        public ChipMovingStateHandler(Transform transform)
        {
            _transform = transform;
        }
        
        public void SetTargetPosition(Vector2Int targetBoardPosition)
        {
            Vector3 targetPosition = new Vector3(targetBoardPosition.x, targetBoardPosition.y, 0);
            _targetPosition = targetPosition;
        }
        
        public void Execute()
        {
            _transform.DOMove(_targetPosition, 0.5f);
        }
    }
}