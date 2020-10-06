using Player;
using System.Collections.Generic;
using UnityEngine;

namespace Environment
{
    public class TileService : MonoBehaviour
    {
        public Transform TileParent;
        public TileView TilePrefab;
        private TilePoolService tilePoolService;

        public PlayerController playerController;

        public int TileLength = 56;
        public int NumberOfTiles = 3;
        [SerializeField]
        private List<TileController> activeTiles = new List<TileController>();
        [SerializeField]
        private int zSpawn = 0;


        private void Start()
        {
            tilePoolService = GetComponent<TilePoolService>();
            for (int i = 0; i < NumberOfTiles; i++)
            {
                SpawnTile();
            }
        }

        public void SetPlayerController(PlayerController playerController)
        {
            this.playerController = playerController;
        }


        private void SpawnTile()
        {
            TileModel tileModel = new TileModel(NumberOfTiles, TileLength);
            TileController tileController = tilePoolService.GetTile(tileModel, TilePrefab, TileParent, zSpawn);
            activeTiles.Add(tileController);
            zSpawn += TileLength;
        }


        public void DestroyTile(TileController tileController)
        {
            tilePoolService.ReturnItem(tileController);
            activeTiles.RemoveAt(0);
        }


        private void Update()
        {
            CheckForNewTile();
        }


        private void CheckForNewTile()
        {
            if (playerController.PlayerView.transform.position.z - 30 > zSpawn - (NumberOfTiles * TileLength))
            {
                SpawnTile();
                DestroyTile(activeTiles[0]);
            }
        }
    }
}
