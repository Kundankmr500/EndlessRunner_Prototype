using UnityEngine;

namespace Environment
{
    public class TileController
    {
        public TileController(TileModel tileModel, TileView tileView, Transform tileParent)
        {
            TileModel = tileModel;
            TileParent = tileParent;
            TileView = GameObject.Instantiate<TileView>(tileView, tileParent);
            TileView.Initialize(this);
        }

        public TileModel TileModel { get; private set; }
        public TileView TileView { get; private set; }
        public Transform TileParent { get; private set; }

        public TileModel GetModel()
        {
            return TileModel;
        }

        internal void DisableTank()
        {
            TileView.DisableTile();
        }
    }
}
