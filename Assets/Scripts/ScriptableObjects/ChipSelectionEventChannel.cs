using System;
using Core.Data;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "ChipSelectionEventChannel", menuName = "ScriptableObjects/ChipSelectionEventChannel")]
    public class ChipSelectionEventChannel: ScriptableObject
    {
        public event Action<ChipData> OnFingerDown; 
        public event Action<ChipData> OnFingerEnter;
        public event Action OnTouchEnded;
        
        public void RaiseFingerDownEvent(ChipData chipData)
        {
            OnFingerDown?.Invoke(chipData);
        }
        
        public void RaiseFingerEnterEvent(ChipData chipData)
        {
            OnFingerEnter?.Invoke(chipData);
        }
        
        public void RaiseTouchEndedEvent()
        {
            OnTouchEnded?.Invoke();
        }
    }
}