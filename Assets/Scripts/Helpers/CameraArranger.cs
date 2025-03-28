using ScriptableObjects;
using UnityEngine;

namespace Helpers
{
    public class CameraArranger: MonoBehaviour
    {
        [SerializeField] private Camera mainCamera;
        [SerializeField] private LevelSettings levelSettings;

        private void Start()
        {
            SetCamera();
        }

        private void SetCamera()
        {
            mainCamera.orthographicSize = levelSettings.width + 3;
            float x = (float)levelSettings.width / 2f - 0.5f;
            float y = (float)levelSettings.height / 2f - 0.5f;
            mainCamera.transform.position = new Vector3(x, y, -10f);
        }
    }
}