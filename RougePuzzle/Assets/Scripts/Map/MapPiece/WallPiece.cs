namespace RougePuzzle.Map
{
    public class WallPiece : MapPiece
    {
        public override void Effect()
        {
            print(nameof(WallPiece) + "effected!");
        }
    }
}