using ScriptableObjects;
using UnityEngine;

namespace Core.Data
{
    public class ChipData: MonoBehaviour
    {
        public Vector2Int BoardPosition { get; private set; }
        public int ChipType { get; private set; }
        [SerializeField] private SpriteRenderer spriteRenderer;
        
        public void Initialize(Vector2Int boardPosition, int chipType, ChipSO chipSO)
        {
            BoardPosition = boardPosition;
            ChipType = chipType;
            spriteRenderer.sprite = chipSO.sprite;
        }
    }
}