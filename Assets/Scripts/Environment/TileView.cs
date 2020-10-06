using UnityEngine;

namespace Environment
{
    public class TileView : MonoBehaviour
    {
        private TileController tileController;

        internal void Initialize(TileController tileController)
        {
            this.tileController = tileController;
        }

        internal void CheckTileTransform(float zSpawn)
        {
            transform.SetPositionAndRotation(transform.forward * zSpawn, transform.rotation);
            gameObject.SetActive(true);

            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(true);
            }
        }

        internal void DisableTile()
        {
            gameObject.SetActive(false);
        }
    }
}
