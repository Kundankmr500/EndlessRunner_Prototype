
namespace Player
{
    public struct PlayerModel
    {
        public float ForwardSpeed { get; }
        public float LaneChangeTime { get; }
        public int MinDesiredLane { get; }
        public int MaxDesiredLane { get; }
        public int LaneDistance { get; }

        public PlayerModel(PlayerScripptableObj playerScripptableObj)
        {
            ForwardSpeed = playerScripptableObj.PlayerForwaedSpeed;
            LaneChangeTime = playerScripptableObj.LaneChangeTime;
            MinDesiredLane = playerScripptableObj.MinDesiredLane;
            MaxDesiredLane = playerScripptableObj.MaxDesiredLane;
            LaneDistance = playerScripptableObj.LaneDistance;
        }
    }
}
