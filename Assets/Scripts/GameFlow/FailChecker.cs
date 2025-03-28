using System.Threading.Tasks;
using ScriptableObjects;
using UnityEngine;
using Enums;
using ScriptableObjects.EventChannel;

namespace GameFlow
{
    public class FailChecker: MonoBehaviour
    {
        [SerializeField] private LevelSettings levelSettings;
        [SerializeField] private MoveCountChangeEventChannel moveCountChangeEventChannel;
        [SerializeField] private ScoreCountChangeEventChannel scoreCountChangeEventChannel;
        [SerializeField] private GameStateChangeEventChannel gameStateChangeEventChannel;
        
        private int _score;
        
        private void OnEnable()
        {
            scoreCountChangeEventChannel.OnScoreCountChanged += OnScoreCountChanged;
            moveCountChangeEventChannel.OnMoveCountChanged += OnMoveCountChanged;
        }
        
        private void OnDisable()
        {
            moveCountChangeEventChannel.OnMoveCountChanged -= OnMoveCountChanged;
            scoreCountChangeEventChannel.OnScoreCountChanged -= OnScoreCountChanged;
        }

        private void OnScoreCountChanged(int score)
        {
            _score = score;
        }

        private async void OnMoveCountChanged(int moveCount)
        {
            if (moveCount < levelSettings.maxMoves) 
                return;
            
            await Task.Delay(50);
            
            if (_score >= levelSettings.targetScore)
                return;

            gameStateChangeEventChannel.RaiseGameStateChangedEvent(GameState.Fail);
        }
    }
}