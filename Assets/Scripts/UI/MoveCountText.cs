using ScriptableObjects;
using UnityEngine;
using TMPro;

namespace UI
{
    public class MoveCountText: MonoBehaviour
    {
        [SerializeField] private MoveCountChangeEventChannel moveCountChangeEventChannel;
        [SerializeField] private LevelSettings levelSettings;
        [SerializeField] private TMP_Text moveCountText;
        
        private void OnEnable()
        {
            moveCountChangeEventChannel.OnMoveCountChanged += OnMoveCountChanged;
        }
        
        private void OnDisable()
        {
            moveCountChangeEventChannel.OnMoveCountChanged -= OnMoveCountChanged;
        }

        private void OnMoveCountChanged(int moveCount)
        {
            int remainingMoves = levelSettings.maxMoves - moveCount;
            moveCountText.text = remainingMoves.ToString();
        }
    }
}