using ScriptableObjects;
using UnityEngine;

namespace GameFlow
{
    public class FailChecker: MonoBehaviour
    {
        [SerializeField] private LevelSettings levelSettings;
        [SerializeField] private MoveCountChangeEventChannel moveCountChangeEventChannel;
        [SerializeField] private ScoreCountChangeEventChannel scoreCountChangeEventChannel;
        
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
                
            Debug.Log("Game Over");
        }
    }
}