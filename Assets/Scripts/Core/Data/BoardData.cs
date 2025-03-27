using System.Collections.Generic;
using UnityEngine;

namespace Core.Data
{
    public class BoardData: MonoBehaviour
    {
        public Dictionary<Vector2Int, Chip> Chips { get; private set; } = new();
        
        public void SetChip(Vector2Int position, Chip chip)
        {
            Chips[position] = chip;
        }
    }
}