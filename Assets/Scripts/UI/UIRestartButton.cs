using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class UIRestartButton: MonoBehaviour
    {
        [SerializeField] private Button button;
        
        private void OnEnable()
        {
            button.onClick.AddListener(RestartLevel);
        }
        
        private void OnDisable()
        {
            button.onClick.RemoveListener(RestartLevel);
        }
        
        private void RestartLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}