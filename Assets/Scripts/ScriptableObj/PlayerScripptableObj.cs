using UnityEngine;

namespace Player
{
    [CreateAssetMenu(fileName = "PlayerConfiguration", menuName = "ScriptableObjects/NewPlayerConfig")]
    public class PlayerScripptableObj : ScriptableObject
    {
        [Range(0, 10)]
        public float PlayerForwaedSpeed;
        [Range(1, 30)]
        public float LaneChangeSpeed;
        [Range(0, 3)]
        public int DistanceBetweenLane;
        [Range(0, 10)]
        public int JumpForce;
        [Range(0, 10)]
        public int GravityValue;

        [Header("Player Input")]

        public KeyCode PlayerRightKey;
        public KeyCode PlayerRightKeyAlter;
        public KeyCode PlayerLeftKey;
        public KeyCode PlayerLeftKeyAlter;
        public KeyCode PlayerUpKey;
        public KeyCode PlayerUpKeyAlter;
        public KeyCode PlayerDownKey;
        public KeyCode PlayerDownKeyAlter;
    }
}
