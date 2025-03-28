using System.Threading.Tasks;
using DG.Tweening;
using Interfaces;
using UnityEngine;

namespace UI.LevelEndStates
{
    public class SuccessStateHandler: IStateHandler
    {
        private RectTransform _popupTransform;
        
        public SuccessStateHandler(RectTransform popupTransform)
        {
            _popupTransform = popupTransform;
        }
        
        public async void Execute()
        {
            Vector2 initialPosition = _popupTransform.anchoredPosition;
            _popupTransform.anchoredPosition += new Vector2(0f, 200f);
            await Task.Delay(300);
            _popupTransform.gameObject.SetActive(true);
            _popupTransform.DOAnchorPos(initialPosition, 0.5f).SetEase(Ease.InSine);
        }
    }
}