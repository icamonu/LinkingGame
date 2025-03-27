using System;
using Core;
using Core.Data;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "ChipSelectionEventChannel", menuName = "ScriptableObjects/ChipSelectionEventChannel")]
    public class ChipSelectionEventChannel: ScriptableObject
    {
        public event Action<Chip> OnFingerDown; 
        public event Action<Chip> OnFingerEnter;
        public event Action OnTouchEnded;
        
        public void RaiseFingerDownEvent(Chip chip)
        {
            OnFingerDown?.Invoke(chip);
        }
        
        public void RaiseFingerEnterEvent(Chip chip)
        {
            OnFingerEnter?.Invoke(chip);
        }
        
        public void RaiseTouchEndedEvent()
        {
            OnTouchEnded?.Invoke();
        }
    }
}