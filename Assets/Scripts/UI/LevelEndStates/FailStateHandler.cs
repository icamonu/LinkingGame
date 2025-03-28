using System.Threading.Tasks;
using Interfaces;
using UnityEngine;
using DG.Tweening;

namespace UI.LevelEndStates
{
    public class FailStateHandler: IStateHandler
    {
        private RectTransform _popupTransform;
        
        public FailStateHandler(RectTransform popupTransform)
        {
            _popupTransform = popupTransform;
        }
        
        public async void Execute()
        {
            _popupTransform.localScale = Vector3.one * 0.8f;
            await Task.Delay(300);
            _popupTransform.gameObject.SetActive(true);
            _popupTransform.DOScale(1.2f, 0.3f).SetEase(Ease.OutElastic);
        }
    }
}