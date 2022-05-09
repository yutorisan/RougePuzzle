namespace RougePuzzle.Map
{
    public class NormalPiece : MapPiece
    {
        public override void Effect()
        {
            print(nameof(NormalPiece) + "effected!");
        }
    }
}