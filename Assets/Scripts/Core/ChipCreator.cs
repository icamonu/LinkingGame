using Core.Data;
using ScriptableObjects;
using UnityEngine;

namespace Core
{
    public class ChipCreator: MonoBehaviour
    {
        [SerializeField] private LevelSettings levelSettings;
        [SerializeField] private BoardData boardData;
        
        private void Start()
        {
            CreateChips();
        }
        
        private void CreateChips()
        {
            for (int y = 0; y < levelSettings.height; y++)
            {
                for (int x = 0; x < levelSettings.height; x++)
                {
                    int chipType = Random.Range(0, levelSettings.chips.Count);
                    ChipSO chipSO = levelSettings.chips[chipType];
                    GameObject chip = Instantiate(levelSettings.chipPrefab, new Vector3(x, y, 0), Quaternion.identity);
                    ChipData chipData = chip.GetComponent<ChipData>();
                    chipData.Initialize(new Vector2Int(x, y), chipType, chipSO);
                    boardData.AddChip(new Vector2Int(x,y), chipData);
                }
            }
        }
    }
}