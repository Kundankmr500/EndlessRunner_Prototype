using UnityEngine;
using Camera;
using Environment;
using Achievement;
using Game;

namespace Player
{
    public class PlayerService : MonoBehaviour
    {
        public GameService GameService;
        public TileService TileService;
        public CameraService CameraService;
        public AchievementService AchievementService;
        public Transform PlayerParent;
        public PlayerView playerPrefab;
        public PlayerScripptableObj playerScripptableObj;

        private void Start()
        {
            SpawnPlayer();
        }

        void SpawnPlayer()
        {
            PlayerModel playerModel = new PlayerModel(playerScripptableObj);
            PlayerController playerController = new PlayerController(playerModel, playerPrefab, PlayerParent);
            playerController.PlayerView.enabled = false;

            CameraService.SetPlayerTransform(playerController);
            TileService.SetPlayerController(playerController);
            AchievementService.SetPlayerController(playerController);
            GameService.SetPlayerController(playerController);
        }

    }
}
