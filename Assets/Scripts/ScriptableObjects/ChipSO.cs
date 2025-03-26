using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "ChipSO", menuName = "ScriptableObjects/ChipSO", order = 0)]
    public class ChipSO : ScriptableObject
    {
        public Sprite sprite;
    }
}