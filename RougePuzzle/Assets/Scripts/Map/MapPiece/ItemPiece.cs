namespace RougePuzzle.Map
{
    public class ItemPiece : MapPiece
    {
        public override void Effect()
        {
            print(nameof(ItemPiece) + "effected!");
        }
    }
}