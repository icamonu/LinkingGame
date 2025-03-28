using System;
using Core;
using UnityEngine;

namespace ScriptableObjects.EventChannel
{
    [CreateAssetMenu(fileName = "ChipPoolEventChannel", menuName = "ScriptableObjects/ChipPoolEventChannel")]
    public class ChipPoolEventChannel: ScriptableObject
    {
        public event Action<Chip> OnChipDisabled;

        public void RaiseChipDisabledEvent(Chip chip)
        {
            OnChipDisabled?.Invoke(chip);
        }
    }
}