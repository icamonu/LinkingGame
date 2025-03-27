using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;

namespace Core.Data
{
    public class ChipData: MonoBehaviour
    {
        public Vector2Int BoardPosition { get; private set; }
        public int ChipType { get; private set; }
        public HashSet<Vector2Int> Neighbours { get; private set; } = new ();
        
        private int _boardWidth;
        private int _boardHeight;
        
        [SerializeField] private SpriteRenderer _spriteRenderer;
        
        public void Initialize(Vector2Int boardPosition, int chipType, Sprite sprite,
            int boardWidth, int boardHeight)
        {
            _boardWidth = boardWidth;
            _boardHeight = boardHeight;
            _spriteRenderer.sprite = sprite;
            ChipType = chipType;
            SetBoardPosition(boardPosition);
        }

        public void SetBoardPosition(Vector2Int boardPosition)
        {
            BoardPosition = boardPosition;
            FindNeighbours();
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