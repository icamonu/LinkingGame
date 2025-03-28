using ScriptableObjects.EventChannel;
using UnityEngine;

namespace Core
{
    public class ChipPoolReturner: MonoBehaviour
    {
        [SerializeField] private Chip chip;
        [SerializeField] private ChipPoolEventChannel chipPoolEventChannel;

        private void OnDisable()
        {
            chipPoolEventChannel.RaiseChipDisabledEvent(chip);
        }
    }
}