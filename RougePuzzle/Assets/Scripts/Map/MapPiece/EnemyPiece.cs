namespace RougePuzzle.Map
{
    public class EnemyPiece : MapPiece
    {
        public override void Effect()
        {
            print(nameof(EnemyPiece) + "effected!");
        }
    }
}