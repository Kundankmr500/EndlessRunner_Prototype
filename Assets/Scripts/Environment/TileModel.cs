
namespace Environment
{
    public struct TileModel
    {
        public int TileLength { get; }
        public int NumberOfTiles { get; }


        public TileModel(int numberOfTiles, int tileLength)
        {
            TileLength = tileLength;
            NumberOfTiles = numberOfTiles;
        }
    }
}
