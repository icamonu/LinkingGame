using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Data;
using ScriptableObjects.EventChannel;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Core
{
    public class BoardShuffler: MonoBehaviour
    {
        [SerializeField] private BoardData boardData;
        [SerializeField] private BoardFillEventChannel boardFillEventChannel;
        [SerializeField] private int maxPossibleChipsInCluster = 7;

        private Dictionary<int, LinkedList<Chip>> _groupedChips = new();
        private HashSet<Chip> _swappedChips = new();

        private void OnEnable()
        {
            boardFillEventChannel.OnBoardFillCompleted += OnBoardFillCompleted;
        }
        
        private void OnDisable()
        {
            boardFillEventChannel.OnBoardFillCompleted -= OnBoardFillCompleted;
        }

        private void OnBoardFillCompleted()
        {
            if(IsThereAnyPossibleLink())
                return;
            
            Shuffle();
        }

        private async void Shuffle()
        {
            await Task.Delay(500);
            _swappedChips.Clear();
            GetChipGroups();
            foreach (int chipType in _groupedChips.Keys)
            {
                if (_groupedChips[chipType].Count < 3)
                    continue;
                
                BuildCluster(chipType);
            }
        }

        private bool IsThereAnyPossibleLink()
        {
            foreach (Chip chip in boardData.Chips.Values)
            {
                if (CheckTheChipForLink(chip))
                    return true;
            }
            
            return false;
        }
        
        private bool CheckTheChipForLink(Chip chip)
        {
            int linkCounter = 0;
            Queue<Chip> queue= new();
            queue.Enqueue(chip);
            HashSet<Chip> visitedChips = new();
            while (queue.Count>0)
            {
                Chip currentChip = queue.Dequeue();

                foreach (Vector2Int chipPosition in currentChip.Neighbours)
                {
                    if (visitedChips.Contains(boardData.Chips[chipPosition]))
                        continue;
                    
                    if (boardData.Chips[chipPosition].ChipType != chip.ChipType)
                        continue;
                    
                    queue.Enqueue(boardData.Chips[chipPosition]);
                }

                visitedChips.Add(currentChip);
                linkCounter++;
            }
            
            return linkCounter >= 3;
        }

        private void BuildCluster(int chipType)
        {
            int clusterSizeCounter = 0;
            
            Chip currentChip= _groupedChips[chipType].First.Value;
            _swappedChips.Add(currentChip);
            _groupedChips[chipType].RemoveFirst();
            int neighborIndex = 0;

            while (clusterSizeCounter<maxPossibleChipsInCluster)
            {
                if(_groupedChips[chipType].Count==0)
                    break;
                
                Chip swapChip = _groupedChips[chipType].First.Value;
                _groupedChips[chipType].RemoveFirst();

                neighborIndex++;
                neighborIndex %= currentChip.Neighbours.Count;
                
                Chip neighborChip = boardData.Chips[currentChip.Neighbours[neighborIndex]];
                if(_swappedChips.Contains(neighborChip))
                    continue;
                
                Swap(swapChip, neighborChip);
                currentChip = swapChip;
                neighborIndex++;
                clusterSizeCounter++;
            }
        }

        private void GetChipGroups()
        {
            _groupedChips.Clear();
            foreach(var chip in boardData.Chips.Values)
            {
                if(!_groupedChips.ContainsKey(chip.ChipType))
                    _groupedChips[chip.ChipType] = new LinkedList<Chip>();
                
                AddRandom(_groupedChips[chip.ChipType], chip);
            }
        }

        private void AddRandom(LinkedList<Chip> chipLinkedList, Chip addedChip)
        {
            int randomNumber= Random.Range(0, 2);
            if(randomNumber==0)
                chipLinkedList.AddFirst(addedChip);
            else
                chipLinkedList.AddLast(addedChip);
        }

        private void Swap(Chip chip1, Chip chip2)
        {
            Vector2Int tempPosition = chip1.BoardPosition;
            chip1.SetBoardPosition(chip2.BoardPosition);
            chip2.SetBoardPosition(tempPosition);
            
            boardData.SetChip(chip1.BoardPosition, chip1);
            boardData.SetChip(chip2.BoardPosition, chip2);
            
            _swappedChips.Add(chip1);
            _swappedChips.Add(chip2);
        }
    }
}