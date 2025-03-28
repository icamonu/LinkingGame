using ScriptableObjects.EventChannel;
using UnityEngine;
using TMPro;

namespace UI
{
    public class ScoreCountText: MonoBehaviour
    {
        [SerializeField] private ScoreCountChangeEventChannel scoreCountChangeEventChannel;
        [SerializeField] private TMP_Text scoreCountText;
        
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
            scoreCountText.text = score.ToString();
        }
    }
}