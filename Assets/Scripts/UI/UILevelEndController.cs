using Enums;
using ScriptableObjects.EventChannel;
using UnityEngine;

namespace UI
{
    public class UILevelEndController: MonoBehaviour
    {
        [SerializeField] private GameObject failPanel;
        [SerializeField] private GameObject successPanel;
        [SerializeField] private GameStateChangeEventChannel gameStateChangeEventChannel;
        
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
            ShowFailPanel(gameState==GameState.Fail);
            ShowSuccessPanel(gameState==GameState.Success);
        }
        
        private void ShowFailPanel(bool isFail)
        {
            failPanel.SetActive(isFail);
        }
        
        private void ShowSuccessPanel(bool isSuccess)
        {
            successPanel.SetActive(isSuccess);
        }
    }
}