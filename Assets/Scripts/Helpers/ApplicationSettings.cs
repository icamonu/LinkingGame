using UnityEngine;

namespace Helpers
{
    public class ApplicationSettings: MonoBehaviour
    {
        private void Start()
        {
            Application.targetFrameRate = 120;
        }
    }
}