using ScriptableObjects;
using UnityEngine;

namespace Core
{
    public class BoardCreator: MonoBehaviour
    {
        [SerializeField] private LevelSettings levelSettings;
        private void Start()
        {
            CreateBoard();
        }
        
        private void CreateBoard()
        {
            for (int y = 0; y < levelSettings.height; y++)
            {
                for (int x = 0; x < levelSettings.width; x++)
                {
                    GameObject tile = Instantiate(levelSettings.tilePrefab, new Vector3(x, y, 0), Quaternion.identity); 
                }
            }
        }
    }
}