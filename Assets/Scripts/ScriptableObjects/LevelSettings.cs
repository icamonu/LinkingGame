using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "LevelSettings", menuName = "ScriptableObjects/LevelSettings", order = 0)]
    public class LevelSettings : ScriptableObject
    {
        [Header("Board Size")]
        public int width;
        public int height;
        
        [Header("Level Targets")]
        public int targetScore;
        public int maxMoves;

        [Header("Chip Types")] 
        public List<ChipSO> chips;
        
        [Header("Prefabs")] 
        public GameObject chipPrefab;
        public GameObject tilePrefab;
    }
}