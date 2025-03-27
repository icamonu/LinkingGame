using Core.Data;
using ScriptableObjects;
using UnityEngine;

namespace Core
{
    public class ChipSelection : MonoBehaviour
    {
        [SerializeField] private ChipData _chipData;
        [SerializeField] private ChipSelectionEventChannel _chipSelectionEventChannel;
        private void OnMouseDown()
        {
            _chipSelectionEventChannel.RaiseFingerDownEvent(_chipData);
        }

        private void OnMouseEnter()
        {
            _chipSelectionEventChannel.RaiseFingerEnterEvent(_chipData);
        }
    }
}