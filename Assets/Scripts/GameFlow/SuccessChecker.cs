using Enums;
using ScriptableObjects;
using ScriptableObjects.EventChannel;
using UnityEngine;

namespace GameFlow
{
    public class SuccessChecker: MonoBehaviour
    {
        [SerializeField] private LevelSettings levelSettings;
        [SerializeField] private ScoreCountChangeEventChannel scoreCountChangeEventChannel;
        [SerializeField] private GameStateChangeEventChannel gameStateChangeEventChannel;
        
        private void OnEnable()
        {
            scoreCountChangeEventChannel.OnScoreCountChanged += OnScoreCountChanged;
        }
        
        private void OnDisable()
        {
            scoreCountChangeEventChannel.OnScoreCountChanged -= OnScoreCountChanged;
        }

        private void OnScoreCountChanged(int score)
        {
            if(score<levelSettings.targetScore)
                return;
            
            gameStateChangeEventChannel.RaiseGameStateChangedEvent(GameState.Success);
        }
    }
}