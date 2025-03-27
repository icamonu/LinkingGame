using System.Collections.Generic;
using UnityEngine;

namespace Core.Data
{
    public class BoardData: MonoBehaviour
    {
        public Dictionary<Vector2Int, ChipData> Chips { get; private set; } = new();
        
        public void AddChip(Vector2Int position, ChipData chip)
        {
            Chips.Add(position, chip);
        }
        
        public void SetChip(Vector2Int position, ChipData chip)
        {
            Chips[position] = chip;
        }
    }
}