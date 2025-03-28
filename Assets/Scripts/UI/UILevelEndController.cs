using System.Collections.Generic;
using Enums;
using Interfaces;
using ScriptableObjects.EventChannel;
using UI.LevelEndStates;
using UnityEngine;

namespace UI
{
    public class UILevelEndController: MonoBehaviour
    {
        [SerializeField] private RectTransform failPanel;
        [SerializeField] private RectTransform successPanel;
        [SerializeField] private GameStateChangeEventChannel gameStateChangeEventChannel;
        
        private Dictionary<GameState, IStateHandler> _stateHandlers = new ();

        private void Awake()
        {
            BuildStateHandlerDictionary();
        }

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
            _stateHandlers.TryGetValue(gameState, out IStateHandler stateHandler);
            stateHandler?.Execute();
        }
        
        private void BuildStateHandlerDictionary()
        {
            _stateHandlers.Add(GameState.Fail, new FailStateHandler(failPanel));
            _stateHandlers.Add(GameState.Success, new SuccessStateHandler(successPanel));
        }
    }
}