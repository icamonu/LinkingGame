using Core.Data;
using ScriptableObjects;
using UnityEngine;

namespace Core
{
    public class LinkController: MonoBehaviour
    {
        [SerializeField] private LinkData _linkData;
        [SerializeField] private TouchController _touchController;
        [SerializeField] private ChipSelectionEventChannel _chipSelectionEventChannel;

        private bool _isLinking = false;
        
        private void OnEnable()
        {
            _chipSelectionEventChannel.OnTouchEnded += OnTouchEnded;
            _chipSelectionEventChannel.OnFingerDown += OnFingerDown;
            _chipSelectionEventChannel.OnFingerEnter += OnFingerEnter;
        }
        
        private void OnDisable()
        {
            _chipSelectionEventChannel.OnTouchEnded -= OnTouchEnded;
            _chipSelectionEventChannel.OnFingerDown -= OnFingerDown;
            _chipSelectionEventChannel.OnFingerEnter -= OnFingerEnter;
        }

        private void OnFingerDown(ChipData chip)
        {
            if(_linkData.Link.Count!=0)
                return;
            
            _linkData.AddChip(chip);
            _isLinking = true;
        }

        private void OnFingerEnter(ChipData chip)
        {
            if (!_isLinking)
                return;
            
            if(_linkData.GetLastChip().Previous?.Value.BoardPosition == chip.BoardPosition)
            {
                _linkData.RemoveLastChip();
                return;
            }
            _linkData.AddChip(chip);
        }

        private void OnTouchEnded()
        {
            if (_linkData.Link.Count >= 3)
            {
                foreach (var chip in _linkData.Link)
                {
                    chip.gameObject.SetActive(false);
                }
            }

            _linkData.ClearLink();
            _isLinking = false;
        }
    }
}