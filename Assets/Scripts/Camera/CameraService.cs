using UnityEngine;
using Player;

namespace Camera
{
    public class CameraService : MonoBehaviour
    {
        public CameraView cameraView;

        public void SetPlayerTransform(PlayerController playerController)
        {
            cameraView.SetTargetTransform(playerController.PlayerView.transform);
        }
    }
}
