using UnityEngine;
using Camera;

namespace Player
{
    public class PlayerService : MonoBehaviour
    {
        public CameraService cameraService;
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
            playerController.InitItem(playerController);
            cameraService.SetPlayerTransform(playerController);
        }

    }
}
