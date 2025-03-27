using Interfaces;
using UnityEngine;
using DG.Tweening;

namespace Core
{
    public class ChipSelectedStateHandler: IStateHandler
    {
        private Transform _transform;
        
        public ChipSelectedStateHandler(Transform transform)
        {
            _transform = transform;
        }
        
        public void Execute()
        {
            _transform.DOScale(1.5f, 0.1f);
        }
    }
}