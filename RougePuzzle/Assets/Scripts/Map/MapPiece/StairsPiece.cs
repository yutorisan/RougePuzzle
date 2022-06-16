namespace RougePuzzle.Map
{
    public class StairsPiece : MapPiece
    {
        public override void Effect()
        {
            print(nameof(StairsPiece) + "effected!");
        }
    }
}