using System.Collections.Generic;
using Interfaces;
using UnityEngine;
using UnityEngine.Serialization;

namespace Core.ChipStates
{
    public class ChipStateController: MonoBehaviour
    {
        [FormerlySerializedAs("chipData")] [SerializeField] private Chip chip;
        [SerializeField] private Transform spriteTransform;
        
        private Dictionary<Enums.ChipState, IStateHandler> _stateHandlers = new ();
        
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

        private void OnChipStateChanged(Enums.ChipState chipState)
        {
            if(_stateHandlers[chipState] is ChipMovingStateHandler movingStateHandler)
                movingStateHandler.SetTargetPosition(chip.BoardPosition);
            
            _stateHandlers[chipState].Execute();
        }
        
        private void BuildStateHandlerDictionary()
        {
            _stateHandlers.Add(Enums.ChipState.Idle, new ChipIdleStateHandler(spriteTransform));
            _stateHandlers.Add(Enums.ChipState.Selected, new ChipSelectedStateHandler(spriteTransform));
            _stateHandlers.Add(Enums.ChipState.Moving, new ChipMovingStateHandler(transform));
            _stateHandlers.Add(Enums.ChipState.Collected, new ChipCollectedStateHandler(spriteTransform));
        }
    }
}