using UnityEngine;
using Generic;

namespace Environment
{
    public class TilePoolService : ServicePoolGeneric<TileController>
    {
        private TileModel tileModel;
        private TileView tilePrefab;
        private Transform tileParent;
        private int zSpawn;


        public TileController GetTile(TileModel tileModel, TileView tilePrefab, Transform tileParent, int zSpawn)
        {
            this.tileModel = tileModel;
            this.tilePrefab = tilePrefab;
            this.tileParent = tileParent;
            this.zSpawn = zSpawn;
            TileController tileController = GetItem();
            InitItem(tileController);
            return tileController;
        }


        public override void InitItem(TileController tileController)
        {
            tileController.TileView.CheckTileTransform(zSpawn);
        }


        protected override TileController CreateItem()
        {
            TileController tileController = new TileController(tileModel, tilePrefab, tileParent);
            Debug.Log("Tile created");
            return tileController;
        }

        public override void ReturnItem(TileController item)
        {
            base.ReturnItem(item);
            item.DisableTank();
            Debug.Log("Tile returned");
        }
    }
}
