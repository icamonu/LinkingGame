using System.Collections.Generic;
using Core.Data;
using Enums;
using ScriptableObjects;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Core
{
    public class ChipCreator: MonoBehaviour
    {
        [SerializeField] private LevelSettings levelSettings;
        [SerializeField] private BoardData boardData;
        [SerializeField] private BoardFillEventChannel boardFillEventChannel;
        [SerializeField] private GameStateChangeEventChannel gameStateChangeEventChannel;

        private void OnEnable()
        {
            boardFillEventChannel.OnBoardFillOrder += OnBoardFillOrder;
            CreateChips();
        }

        private void OnDisable()
        {
            boardFillEventChannel.OnBoardFillOrder -= OnBoardFillOrder;
        }
        
        private void OnBoardFillOrder(List<Vector2Int> emptyPositions)
        {
            foreach (Vector2Int emptyPosition in emptyPositions)
            {
                CreateChip(emptyPosition.x, emptyPosition.y);
            }
        }

        private void CreateChips()
        {
            for (int y = 0; y < levelSettings.height; y++)
            {
                for (int x = 0; x < levelSettings.height; x++)
                {
                    CreateChip(x, y, true);
                }
            }
            
            gameStateChangeEventChannel.RaiseGameStateChangedEvent(GameState.GameStarted);
        }

        private void CreateChip(int x, int y, bool onGameStart = false)
        {
            int chipType = Random.Range(0, levelSettings.chips.Count);
            ChipSO chipSo = levelSettings.chips[chipType];
            Vector3 instantiatePosition = onGameStart ? new Vector3(x, y, 0) : new Vector3(x, y + 20, 0);
            GameObject chipObj = Instantiate(levelSettings.chipPrefab, instantiatePosition, Quaternion.identity);
            Chip chip = chipObj.GetComponent<Chip>();
            chip.Initialize(new Vector2Int(x, y), chipType, chipSo.sprite, 
                levelSettings.width, levelSettings.height);
            boardData.SetChip(new Vector2Int(x,y), chip);
        }
    }
}