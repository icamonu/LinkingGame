using System.Collections.Generic;
using Core.Data;
using Enums;
using Pooling;
using ScriptableObjects;
using ScriptableObjects.EventChannel;
using UnityEngine;

namespace Core
{
    public class ChipPool: ObjectPool<Chip>
    {
        [SerializeField] private BoardData boardData;
        [SerializeField] private ChipCreator chipCreator;
        [SerializeField] private BoardFillEventChannel boardFillEventChannel;
        [SerializeField] private GameStateChangeEventChannel gameStateChangeEventChannel;
        [SerializeField] private ChipPoolEventChannel chipPoolEventChannel;
        [SerializeField] private LevelSettings levelSettings;

        private void Start()
        {
            CreateChips();
        }
        
        private void OnEnable()
        {
            boardFillEventChannel.OnBoardFillOrder += OnBoardFillOrder;
            chipPoolEventChannel.OnChipDisabled += ReturnToPool;
        }

        private void OnDisable()
        {
            boardFillEventChannel.OnBoardFillOrder -= OnBoardFillOrder;
            chipPoolEventChannel.OnChipDisabled -= ReturnToPool;
        }

        private void OnBoardFillOrder(List<Vector2Int> emptyPositions)
        {
            foreach (Vector2Int emptyPosition in emptyPositions)
            {
                if(pool.Count == 0)
                    chipCreator.CreateChip(emptyPosition.x, emptyPosition.y);
                else
                {
                    Chip chip = Get();
                    chip.gameObject.SetActive(true);
                    chipCreator.PrepareChip(chip,emptyPosition);
                }
            }
            
            boardFillEventChannel.RaiseBoardFillCompletedEvent();
        }
        
        private void CreateChips()
        {
            for (int y = 0; y < levelSettings.height; y++)
            {
                for (int x = 0; x < levelSettings.width; x++)
                {
                    chipCreator.CreateChip(x, y, true);
                }
            }
            
            boardFillEventChannel.RaiseBoardFillCompletedEvent();
            gameStateChangeEventChannel.RaiseGameStateChangedEvent(GameState.GameStarted);
        }
    }
}