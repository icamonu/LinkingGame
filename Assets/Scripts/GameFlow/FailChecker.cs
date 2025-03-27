using ScriptableObjects;
using UnityEngine;
using Enums;

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
            moveCountChangeEventChannel.OnMoveCountChanged += OnMoveCountChanged;
            scoreCountChangeEventChannel.OnScoreCountChanged += OnScoreCountChanged;
        }
        
        private void OnDisable()
        {
            moveCountChangeEventChannel.OnMoveCountChanged -= OnMoveCountChanged;
            scoreCountChangeEventChannel.OnScoreCountChanged -= OnScoreCountChanged;
        }

        //This is not a good place to keep them, but for now, it is okay.
        private void Start()
        {
            moveCountChangeEventChannel.RaiseMoveCountChangedEvent(0);
            scoreCountChangeEventChannel.RaiseScoreCountChangedEvent(0);
        }

        private void OnScoreCountChanged(int score)
        {
            _score = score;
        }

        private void OnMoveCountChanged(int moveCount)
        {
            if (moveCount < levelSettings.maxMoves) 
                return;
            
            if(_score>=levelSettings.targetScore)
                return;
                
            gameStateChangeEventChannel.RaiseGameStateChangedEvent(GameState.Fail);
        }
    }
}