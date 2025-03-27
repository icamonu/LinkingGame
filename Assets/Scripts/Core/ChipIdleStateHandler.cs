using DG.Tweening;
using Interfaces;
using UnityEngine;

namespace Core
{
    public class ChipIdleStateHandler: IStateHandler
    {
        private Transform _transform;
        
        public ChipIdleStateHandler(Transform transform)
        {
            _transform = transform;
        }

        public void Execute()
        {
            _transform.DOScale(1f, 0.1f);
        }
    }
}