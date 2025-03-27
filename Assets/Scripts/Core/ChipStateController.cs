using System.Collections.Generic;
using Core.Data;
using Enums;
using Interfaces;
using UnityEngine;

namespace Core
{
    public class ChipStateController: MonoBehaviour
    {
        [SerializeField] private ChipData chipData;
        [SerializeField] private Transform spriteTransform;
        
        private Dictionary<ChipState, IStateHandler> _stateHandlers = new ();
        
        private void Awake()
        {
            BuildStateHandlerDictionary();
        }

        private void OnEnable()
        {
            chipData.OnChipStateChanged += OnChipStateChanged;
        }
        
        private void OnDisable()
        {
            chipData.OnChipStateChanged -= OnChipStateChanged;
        }

        private void OnChipStateChanged(ChipState chipState)
        {
            if(_stateHandlers[chipState] is ChipMovingStateHandler movingStateHandler)
                movingStateHandler.SetTargetPosition(chipData.BoardPosition);
            
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