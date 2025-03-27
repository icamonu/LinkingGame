using Core.Data;
using ScriptableObjects;
using UnityEngine;

namespace Core
{
    public class ChipSelection : MonoBehaviour
    {
        [SerializeField] private ChipData chipData;
        [SerializeField] private ChipSelectionEventChannel chipSelectionEventChannel;
        private void OnMouseDown()
        {
            chipSelectionEventChannel.RaiseFingerDownEvent(chipData);
        }

        private void OnMouseEnter()
        {
            chipSelectionEventChannel.RaiseFingerEnterEvent(chipData);
        }
    }
}