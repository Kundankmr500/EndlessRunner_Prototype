using UnityEngine;

namespace Player
{
    public class PlayerController
    {
        public PlayerController(PlayerModel playerModel, PlayerView playerPrefab, Transform playerParent)
        {
            PlayerModel = playerModel;
            PlayerParent = playerParent;
            PlayerView = GameObject.Instantiate<PlayerView>(playerPrefab, playerParent);
            PlayerView.Initialize(this);
        }

        public PlayerModel PlayerModel { get; private set; }
        public PlayerView PlayerView { get; private set; }
        public Transform PlayerParent { get; private set; }

        public PlayerModel GetModel()
        {
            return PlayerModel;
        }

        internal void InitItem(PlayerController playerController)
        {
            playerController.PlayerView.CheckPlayerTransform();
        }
    }
}
