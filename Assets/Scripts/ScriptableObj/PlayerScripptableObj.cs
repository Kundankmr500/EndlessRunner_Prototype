using UnityEngine;

namespace Player
{
    [CreateAssetMenu(fileName = "PlayerConfiguration", menuName = "ScriptableObjects/NewPlayerConfig")]
    public class PlayerScripptableObj : ScriptableObject
    {
        [Range(1, 10)]
        public float PlayerForwaedSpeed;
        [Range(1, 30)]
        public float LaneChangeTime;
        [Range(0, 3)]
        public int MinDesiredLane;
        [Range(0, 3)]
        public int MaxDesiredLane;
        [Range(0, 10)]
        public int LaneDistance;
    }
}
