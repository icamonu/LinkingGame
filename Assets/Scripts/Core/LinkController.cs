using System.Collections.Generic;
using Core.Data;
using ScriptableObjects.EventChannel;
using UnityEngine;

namespace Core
{
    public class LinkController: MonoBehaviour
    {
        [SerializeField] private LinkData linkData;
        [SerializeField] private TouchController touchController;
        [SerializeField] private ChipSelectionEventChannel chipSelectionEventChannel;
        [SerializeField] private ChipCollectionEventChannel chipCollectionEventChannel;
        
        private bool _isLinking = false;
        private List<Vector2Int> _collectedChipPositions = new ();
        
        private void OnEnable()
        {
            chipSelectionEventChannel.OnTouchEnded += OnTouchEnded;
            chipSelectionEventChannel.OnFingerDown += OnFingerDown;
            chipSelectionEventChannel.OnFingerEnter += OnFingerEnter;
        }
        
        private void OnDisable()
        {
            chipSelectionEventChannel.OnTouchEnded -= OnTouchEnded;
            chipSelectionEventChannel.OnFingerDown -= OnFingerDown;
            chipSelectionEventChannel.OnFingerEnter -= OnFingerEnter;
        }

        private void OnFingerDown(Chip chip)
        {
            if(linkData.Link.Count!=0)
                return;
            
            linkData.AddChip(chip);
            _collectedChipPositions.Clear();
            _isLinking = true;
        }

        private void OnFingerEnter(Chip chip)
        {
            if (!_isLinking)
                return;
            
            if(linkData.GetLastChip().Previous?.Value.BoardPosition == chip.BoardPosition)
            {
                linkData.RemoveLastChip();
                return;
            }
            linkData.AddChip(chip);
        }

        private void OnTouchEnded()
        {
            if (linkData.Link.Count >= 3)
            {
                foreach (var chip in linkData.Link)
                {
                    _collectedChipPositions.Add(chip.BoardPosition);
                }
                
                chipCollectionEventChannel.RaiseChipCollectionEvent(_collectedChipPositions);
            }
            
            linkData.ClearLink();
            _isLinking = false;
        }
    }
}