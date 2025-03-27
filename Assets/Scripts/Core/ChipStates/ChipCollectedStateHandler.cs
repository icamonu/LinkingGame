using DG.Tweening;
using Interfaces;
using UnityEngine;

namespace Core.ChipStates
{
    public class ChipCollectedStateHandler: IStateHandler
    {
        private Transform _transform;
        
        public ChipCollectedStateHandler(Transform transform)
        {
            _transform = transform;
        }
        
        public void Execute()
        {
            _transform.DOScale(0f, 0.1f).OnComplete(Disable);
        }

        private void Disable()
        {
            _transform.gameObject.SetActive(false);
        }
    }
}