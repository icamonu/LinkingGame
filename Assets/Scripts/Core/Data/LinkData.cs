using System.Collections.Generic;
using UnityEngine;

namespace Core.Data
{
    public class LinkData: MonoBehaviour
    {
        public LinkedList<Chip> Link { get; private set; } = new();
        private int _collectedChipType=-1;
        
        public void AddChip(Chip chip)
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
            chip.OnAddedToLink();
        }
        
        public void RemoveLastChip()
        {
            Chip lastChip = Link.Last.Value;
            lastChip.OnRemovedFromLink();
            Link.RemoveLast();
        }
        
        public void ClearLink()
        {
            foreach (Chip chip in Link)
            {
                chip.OnRemovedFromLink();
            }
            Link.Clear();
            _collectedChipType = -1;
        }
        
        public LinkedListNode<Chip> GetLastChip()
        {
            return Link.Last;
        }
    }
}