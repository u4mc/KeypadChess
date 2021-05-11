
using System.Collections.Generic;

public class PieceArray
{
    public PieceArray[] pieceArray { get; set; }
}

public class Piece
{
    public string name { get; set; }
    public bool rookMove { get; set; }
    public bool bishopMove { get; set; }
    public bool kingMove { get; set; }
    public Legalmove[] legalMoves { get; set; }

    public int [][]convertLegalMoves(Legalmove[] legalMoves)
    {
        int l = legalMoves.Length;
        int[][] array=new int[l][];

        return array;
    }

}

public class Legalmove
{
    public int x { get; set; }
    public int y { get; set; }
}
