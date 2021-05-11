using System;
using System.Collections.Generic;
using System.Text;

namespace KeyChess
{
    class StackNumber
    {

        public StackNumber(Key k,List<Key> potentialMoves)
        {
            currentKey = k;
            this.potentialMoves = new Stack<Key>();

            foreach(Key move in potentialMoves)
            {
                //Console.Out.WriteLine("MOVE"+move.name);
                this.potentialMoves.Push(move);
            }
            //Console.Out.WriteLine("Finish init stack number");
        }
        public Key currentKey { get; set; }

        public Stack<Key> potentialMoves { get; set; }

        public Key getNextMove()
        {

            Key k = null;
            //gets next move in potential moves
            //if no moves left then return with null
            if(potentialMoves.Count!=0)
            {
                k=potentialMoves.Pop();
            }
            return k;
        }
    }
}
