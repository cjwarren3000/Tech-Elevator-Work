namespace Individual.Exercises.Classes
{
    public class FruitTree
    {
        public FruitTree (string typeOfFruit, int startingPiecesOfFruit)
        {
            TypeOfFruit = typeOfFruit;
            PiecesOfFruitLeft = startingPiecesOfFruit;
        }

        public string TypeOfFruit
        {
            get;
        }

        public int PiecesOfFruitLeft
        {
            get; private set;
        }

        public bool PickFruit(int numberOfPiecesToRemove)
        {
            if (numberOfPiecesToRemove <= PiecesOfFruitLeft)
            {
                PiecesOfFruitLeft = PiecesOfFruitLeft - numberOfPiecesToRemove;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
