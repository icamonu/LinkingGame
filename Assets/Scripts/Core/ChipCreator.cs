using Core.Data;
using ScriptableObjects;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Core
{
    public class ChipCreator: MonoBehaviour
    {
        [SerializeField] private LevelSettings levelSettings;
        [SerializeField] private BoardData boardData;
        
        public void CreateChip(int x, int y, bool onGameStart = false)
        {
            GameObject chipObj = Instantiate(levelSettings.chipPrefab);
            Chip chip = chipObj.GetComponent<Chip>();
            PrepareChip(chip, new Vector2Int(x, y), onGameStart);
        }

        public void PrepareChip(Chip chip, Vector2Int boardPosition, bool onGameStart = false)
        {
            int chipType = Random.Range(0, levelSettings.chips.Count);
            ChipSO chipSo = levelSettings.chips[chipType];
            int x= boardPosition.x;
            int y= boardPosition.y;
            Vector3 instantiatePosition = onGameStart ? new Vector3(x, y, 0) : new Vector3(x, y + 20, 0);
            chip.Initialize(boardPosition, chipType, chipSo.sprite, levelSettings.width, levelSettings.height);
            chip.transform.position = instantiatePosition;
            boardData.SetChip(boardPosition, chip);
        }
    }
}