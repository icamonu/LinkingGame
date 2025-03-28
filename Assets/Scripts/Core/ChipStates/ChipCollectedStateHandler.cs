using DG.Tweening;
using Interfaces;
using UnityEngine;

namespace Core.ChipStates
{
    public class ChipCollectedStateHandler: IStateHandler
    {
        private Transform _spriteTransform;
        private Transform _chipTransform;
        
        public ChipCollectedStateHandler(Transform chipTransform, Transform spriteTransform)
        {
            _chipTransform = chipTransform;
            _spriteTransform = spriteTransform;
        }
        
        public void Execute()
        {
            _spriteTransform.DOScale(0f, 0.1f).OnComplete(Disable);
        }

        private void Disable()
        {
            _chipTransform.gameObject.SetActive(false);
        }
    }
}