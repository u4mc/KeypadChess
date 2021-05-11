using System;
using System.IO;


namespace KeyChess
{
    class Program
    {
        static void Main(string[] args)
        {
            String piece;
            String numLength;
            String consoleOutput;
            Simulation s = new Simulation();
            //input piece
            Console.WriteLine("knight, pawn, rook, bishop, king, queen");
            piece = Console.ReadLine();
            s.inputPiece(piece);
            Console.WriteLine("length of number");
            numLength = Console.ReadLine();
            s.inputNumLength(Int16.Parse(numLength));
            Console.WriteLine("write output to console (true/false)");
            consoleOutput = Console.ReadLine();
            s.consoleOut(bool.Parse(consoleOutput));
            s.run();
            Console.WriteLine("end");

        }
    }
}
