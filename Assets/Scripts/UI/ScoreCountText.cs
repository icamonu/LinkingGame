using ScriptableObjects;
using ScriptableObjects.EventChannel;
using UnityEngine;
using TMPro;
using System.Text;

namespace UI
{
    public class ScoreCountText: MonoBehaviour
    {
        [SerializeField] private ScoreCountChangeEventChannel scoreCountChangeEventChannel;
        [SerializeField] private TMP_Text scoreCountText;
        [SerializeField] private LevelSettings levelSettings;

        private StringBuilder _stringBuilder = new StringBuilder();
        
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
            _stringBuilder.Clear();
            _stringBuilder.Append(score);
            _stringBuilder.Append("/");
            _stringBuilder.Append(levelSettings.targetScore);
            scoreCountText.text = _stringBuilder.ToString();
        }
    }
}