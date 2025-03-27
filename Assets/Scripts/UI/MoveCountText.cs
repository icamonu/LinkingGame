using ScriptableObjects;
using UnityEngine;
using TMPro;

namespace UI
{
    public class MoveCountText: MonoBehaviour
    {
        [SerializeField] private MoveCountChangeEventChannel moveCountChangeEventChannel;
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
            moveCountText.text = moveCount.ToString();
        }
    }
}