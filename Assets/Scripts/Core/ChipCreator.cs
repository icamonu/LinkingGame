using Core.Data;
using ScriptableObjects;
using UnityEngine;

namespace Core
{
    public class ChipCreator: MonoBehaviour
    {
        [SerializeField] private LevelSettings _levelSettings;
        [SerializeField] private BoardData _boardData;
        
        private void Start()
        {
            CreateChips();
        }
        
        private void CreateChips()
        {
            for (int y = 0; y < _levelSettings.height; y++)
            {
                for (int x = 0; x < _levelSettings.height; x++)
                {
                    int chipType = Random.Range(0, _levelSettings.chips.Count);
                    ChipSO chipSO = _levelSettings.chips[chipType];
                    GameObject chip = Instantiate(_levelSettings.chipPrefab, new Vector3(x, y, 0), Quaternion.identity);
                    ChipData chipData = chip.GetComponent<ChipData>();
                    chipData.Initialize(new Vector2Int(x, y), chipType, chipSO.sprite, 
                        _levelSettings.width, _levelSettings.height);
                    _boardData.AddChip(new Vector2Int(x,y), chipData);
                }
            }
        }
    }
}