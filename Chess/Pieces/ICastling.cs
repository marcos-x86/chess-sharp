namespace Chess.Pieces
{
    public interface ICastling
    {
        public void EvaluateCastling(bool[,] mat);
    }
}