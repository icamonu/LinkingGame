using System.Collections.Generic;
using Core.Data;
using ScriptableObjects;
using UnityEngine;

namespace Core
{
    public class ColumnSorter: MonoBehaviour
    {
        [SerializeField] private BoardData boardData;
        [SerializeField] private ChipCollectionEventChannel chipCollectionEventChannel;
        
        private List<ChipData> _remainingChipsOnColumn = new ();
        private void OnEnable()
        {
            chipCollectionEventChannel.OnChipCollectionCompleted += OnChipCollectionCompleted;
        }
        
        private void OnDisable()
        {
            chipCollectionEventChannel.OnChipCollectionCompleted -= OnChipCollectionCompleted;
        }

        private void OnChipCollectionCompleted()
        {
            RearrangeBoard();
        }

        private void RearrangeBoard()
        {
            Vector2Int currentColumn = new Vector2Int(0, 0);

            while (boardData.Chips.ContainsKey(currentColumn))
            {
                SortColumn(currentColumn.x);
                currentColumn.x++;
            }
        }

        private void SortColumn(int column)
        {
            GetRemainingChips(column);
            MoveChipsDown(column);
        }

        private void GetRemainingChips(int column)
        {
            _remainingChipsOnColumn.Clear();
            Vector2Int currentPosition = new Vector2Int(column, 0);
            while (boardData.Chips.ContainsKey(currentPosition))
            {
                if (boardData.Chips[currentPosition] != null)
                {
                    _remainingChipsOnColumn.Add(boardData.Chips[currentPosition]);
                }
                currentPosition.y++;
            }
        }
        
        private void MoveChipsDown(int column)
        {
            Vector2Int currentPosition = new Vector2Int(column, 0);
            while (boardData.Chips.ContainsKey(currentPosition))
            {
                if (!boardData.Chips.ContainsKey(currentPosition))
                    break;
                
                if (currentPosition.y < _remainingChipsOnColumn.Count)
                {
                    boardData.SetChip(currentPosition, _remainingChipsOnColumn[currentPosition.y]);
                    _remainingChipsOnColumn[currentPosition.y].SetBoardPosition(currentPosition);
                }
                else
                {
                    boardData.SetChip(currentPosition, null);
                }
                
                currentPosition.y++;
            }
        }
    }
}