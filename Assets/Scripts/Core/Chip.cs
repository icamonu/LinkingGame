using System;
using System.Collections.Generic;
using Enums;
using UnityEngine;

namespace Core
{
    public class Chip: MonoBehaviour
    {
        public Vector2Int BoardPosition { get; private set; }
        public int ChipType { get; private set; }
        public HashSet<Vector2Int> Neighbours { get; } = new ();
        public Action<ChipState> OnChipStateChanged;
        
        private int _boardWidth;
        private int _boardHeight;
        
        [SerializeField] private SpriteRenderer spriteRenderer;
        
        public void Initialize(Vector2Int boardPosition, int chipType, Sprite sprite,
            int boardWidth, int boardHeight)
        {
            _boardWidth = boardWidth;
            _boardHeight = boardHeight;
            spriteRenderer.sprite = sprite;
            ChipType = chipType;
            SetBoardPosition(boardPosition);
            OnChipStateChanged?.Invoke(ChipState.Idle);
        }
        
        public void OnAddedToLink()
        {
            OnChipStateChanged?.Invoke(ChipState.Selected);
        }
        
        public void OnRemovedFromLink()
        {
            OnChipStateChanged?.Invoke(ChipState.Idle);
        }
        
        public void OnCollected()
        {
            OnChipStateChanged?.Invoke(ChipState.Collected);
        }

        public void SetBoardPosition(Vector2Int boardPosition)
        {
            BoardPosition = boardPosition;
            FindNeighbours();
            OnChipStateChanged?.Invoke(ChipState.Moving);
        }

        private void FindNeighbours()
        {
            Neighbours.Clear();
            if(BoardPosition.x > 0)
                Neighbours.Add(new Vector2Int(BoardPosition.x - 1, BoardPosition.y));
            if(BoardPosition.x < _boardWidth - 1)
                Neighbours.Add(new Vector2Int(BoardPosition.x + 1, BoardPosition.y));
            if(BoardPosition.y > 0)
                Neighbours.Add(new Vector2Int(BoardPosition.x, BoardPosition.y - 1));
            if(BoardPosition.y < _boardHeight - 1)
                Neighbours.Add(new Vector2Int(BoardPosition.x, BoardPosition.y + 1));
        }
    }
}