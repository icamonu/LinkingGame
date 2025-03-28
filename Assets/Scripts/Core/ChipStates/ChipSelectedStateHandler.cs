using DG.Tweening;
using Interfaces;
using UnityEngine;

namespace Core.ChipStates
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
            _transform.DOScale(1.2f, 0.1f);
        }
    }
}