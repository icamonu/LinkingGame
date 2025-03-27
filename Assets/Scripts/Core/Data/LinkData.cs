using System.Collections.Generic;
using UnityEngine;

namespace Core.Data
{
    public class LinkData: MonoBehaviour
    {
        public LinkedList<ChipData> Link { get; private set; } = new();
        private int _collectedChipType=-1;
        
        public void AddChip(ChipData chip)
        {
            if (Link.Contains(chip))
                return;
            
            if(_collectedChipType==-1)
                _collectedChipType = chip.ChipType;
            
            if(chip.ChipType!=_collectedChipType)
                return;
            
            if(Link.Count!=0 && !GetLastChip().Value.Neighbours.Contains(chip.BoardPosition))
                return;
            
            Link.AddLast(chip);
        }
        
        public void RemoveLastChip()
        {
            Link.RemoveLast();
        }
        
        public void ClearLink()
        {
            Link.Clear();
            _collectedChipType = -1;
        }
        
        public LinkedListNode<ChipData> GetLastChip()
        {
            return Link.Last;
        }
    }
}