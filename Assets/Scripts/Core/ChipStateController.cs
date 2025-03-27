using System.Collections.Generic;
using Core.Data;
using Enums;
using Interfaces;
using UnityEngine;
using UnityEngine.Serialization;

namespace Core
{
    public class ChipStateController: MonoBehaviour
    {
        [FormerlySerializedAs("chipData")] [SerializeField] private Chip chip;
        [SerializeField] private Transform spriteTransform;
        
        private Dictionary<ChipState, IStateHandler> _stateHandlers = new ();
        
        private void Awake()
        {
            BuildStateHandlerDictionary();
        }

        private void OnEnable()
        {
            chip.OnChipStateChanged += OnChipStateChanged;
        }
        
        private void OnDisable()
        {
            chip.OnChipStateChanged -= OnChipStateChanged;
        }

        private void OnChipStateChanged(ChipState chipState)
        {
            if(_stateHandlers[chipState] is ChipMovingStateHandler movingStateHandler)
                movingStateHandler.SetTargetPosition(chip.BoardPosition);
            
            _stateHandlers[chipState].Execute();
        }
        
        private void BuildStateHandlerDictionary()
        {
            _stateHandlers.Add(ChipState.Idle, new ChipIdleStateHandler(spriteTransform));
            _stateHandlers.Add(ChipState.Selected, new ChipSelectedStateHandler(spriteTransform));
            _stateHandlers.Add(ChipState.Moving, new ChipMovingStateHandler(transform));
            _stateHandlers.Add(ChipState.Collected, new ChipCollectedStateHandler(spriteTransform));
        }
    }
}