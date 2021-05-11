using System;
using System.Collections.Generic;
using System.Text;

namespace KeyChess
{
    class StackManager
    {
        Stack<StackNumber> stack=new Stack<StackNumber>();
        Keypad keypad;
        List<Key> startingKeys;
        Piece piece;
        int numCount;
        int numLength;
        bool consoleOut;

        public StackManager(List<Key> startingKeys,Keypad keypad, Piece p,int numLength,bool consoleOut)
        {
            this.startingKeys = startingKeys;
            this.keypad = keypad;
            this.piece = p;
            this.numLength = numLength;
            this.consoleOut = consoleOut;
        }
        public void run()
        {
            Console.Out.WriteLine("Start stack");
            foreach (Key key in startingKeys)
            {
                startStack(key);
            }
            Console.Out.WriteLine("Final number count "+numCount);
        }

        private void startStack(Key k)
        {
            //Console.Out.WriteLine("Push " + k.name + " onto stack");
            push(k);
            //Console.Out.WriteLine("Stack count"+stack.Count);
            while(stack.Count!=0)
            {
                next();
            }

            return;
        }
        public void next()
        {
            //Console.WriteLine("Get next move");
            if(stack.Count==numLength)
            {
                getNum();
                return;
            }

            Key nextMove=stack.Peek().getNextMove();

            if(nextMove==null)
            {
                pop();
                return;
            }

            push(nextMove);

            return;
        }

        private void getNum()
        {
            if (consoleOut == true)
            {
                foreach(StackNumber s in stack)
                {
                
                    Console.Out.Write(s.currentKey.name);
                }
                Console.WriteLine();
            }


            pop();
            numCount++;
        }
        private void push(Key k)
        {
            stack.Push(new StackNumber(k, keypad.getPossibleMoves(k,piece)));
        }

        private void pop()
        {
            stack.Pop();

        }
    }
}
