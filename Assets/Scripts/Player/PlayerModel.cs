
using UnityEngine;

namespace Player
{
    public struct PlayerModel
    {
        public float ForwardSpeed { get; }
        public float LaneChangeSpeed { get; }
        public int DistanceBetweenLane { get; }
        public int JumpForce { get; }
        public int GravityValue { get; }
        public KeyCode PlayerRightKey { get; }
        public KeyCode PlayerRightKeyAlter { get; }
        public KeyCode PlayerLeftKey { get; }
        public KeyCode PlayerLeftKeyAlter { get; }
        public KeyCode PlayerUpKey { get; }
        public KeyCode PlayerUpKeyAlter { get; }
        public KeyCode PlayerDownKey { get; }
        public KeyCode PlayerDownKeyAlter { get; }

        public PlayerModel(PlayerScripptableObj playerScripptableObj)
        {
            ForwardSpeed = playerScripptableObj.PlayerForwaedSpeed;
            LaneChangeSpeed = playerScripptableObj.LaneChangeSpeed;
            DistanceBetweenLane = playerScripptableObj.DistanceBetweenLane;
            JumpForce = playerScripptableObj.JumpForce;
            GravityValue = playerScripptableObj.GravityValue;
            PlayerRightKey = playerScripptableObj.PlayerRightKey;
            PlayerRightKeyAlter = playerScripptableObj.PlayerRightKeyAlter;
            PlayerLeftKey = playerScripptableObj.PlayerLeftKey;
            PlayerLeftKeyAlter = playerScripptableObj.PlayerLeftKeyAlter;
            PlayerUpKey = playerScripptableObj.PlayerUpKey;
            PlayerUpKeyAlter = playerScripptableObj.PlayerUpKeyAlter;
            PlayerDownKey = playerScripptableObj.PlayerDownKey;
            PlayerDownKeyAlter = playerScripptableObj.PlayerDownKeyAlter;
        }
    }
}
