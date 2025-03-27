using Core.Data;
using ScriptableObjects;
using UnityEngine;

namespace Core
{
    public class BoardCreator: MonoBehaviour
    {
        [SerializeField] private LevelSettings _levelSettings;
        private void Start()
        {
            CreateBoard();
        }
        
        private void CreateBoard()
        {
            for (int y = 0; y < _levelSettings.height; y++)
            {
                for (int x = 0; x < _levelSettings.height; x++)
                {
                    GameObject tile = Instantiate(_levelSettings.tilePrefab, new Vector3(x, y, 0), Quaternion.identity); 
                }
            }
        }
    }
}