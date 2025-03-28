using System;
using Enums;
using UnityEngine;

namespace ScriptableObjects.EventChannel
{
    [CreateAssetMenu(fileName = "GameStateChangeEventChannel", menuName = "ScriptableObjects/GameStateChangeEventChannel")]
    public class GameStateChangeEventChannel: ScriptableObject
    {
        public event Action<GameState> OnGameStateChanged;
        
        public void RaiseGameStateChangedEvent(GameState gameState)
        {
            OnGameStateChanged?.Invoke(gameState);
        }
    }
}