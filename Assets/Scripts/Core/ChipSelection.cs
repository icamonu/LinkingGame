using Core.Data;
using Enums;
using ScriptableObjects;
using UnityEngine;

namespace Core
{
    public class ChipSelection : MonoBehaviour
    {
        [SerializeField] private ChipData chipData;
        [SerializeField] private ChipSelectionEventChannel chipSelectionEventChannel;
        [SerializeField] private GameStateChangeEventChannel gameStateChangeEventChannel;
        private bool _isPlayable = true;
        
        private void OnEnable()
        {
            gameStateChangeEventChannel.OnGameStateChanged += OnGameStateChanged;
        }
        
        private void OnDisable()
        {
            gameStateChangeEventChannel.OnGameStateChanged -= OnGameStateChanged;
        }
        
        private void OnGameStateChanged(GameState gameState)
        {
            if (gameState != GameState.GameStarted)
                _isPlayable = false;
        }
        private void OnMouseDown()
        {
            if (!_isPlayable)
                return;
            
            chipSelectionEventChannel.RaiseFingerDownEvent(chipData);
        }

        private void OnMouseEnter()
        {
            if (!_isPlayable)
                return;
            
            chipSelectionEventChannel.RaiseFingerEnterEvent(chipData);
        }
    }
}