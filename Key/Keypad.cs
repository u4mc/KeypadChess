using System;
using System.Collections.Generic;
using System.Text;

namespace KeyChess
{
    class Keypad
    {

        private Key[,] keypad;
        private int xBound=3;
        private int yBound=4;

        public void populateKeypad(KeyArray keyArray)
        {
            //get bounds for x
            //get bounds for y


            keypad = new Key[xBound,yBound];

            
            foreach (Key k in keyArray.keys)
            {//set keys to specified coordinates
                keypad[k.x,k.y]= k;
            }
        }
        public List<Key> getPossibleMoves(Key k,Piece p)
        {//get all possible moves given a piece and position on the keypad
            List<Key> moves = new List<Key>();
            int[][] possibleMoves=null;
            //king
            if (p.name=="king")
            {
                possibleMoves = new int[][]
                {
                    new int[]{1,0},
                    new int[]{1,1},
                     new int[]{ 0, 1 }, 
                     new int[]{ -1, 1 }, 
                     new int[]{ -1, 0 }, 
                     new int[]{ -1, -1 }, 
                     new int[]{ 0, -1 }, 
                     new int[]{ 1, -1 }
                };
            }

            if (p.name=="knight")
            {
                possibleMoves = new int[][]
{
                    new int[]{2,1},
                    new int[]{1,2},
                     new int[]{2,-1 },
                     new int[]{ 1,-2 },
                     new int[]{ -1,-2 },
                     new int[]{ -2,-1 },
                     new int[]{ -2,1},
                     new int[]{ -1,2 }
};
            }

            if(p.name=="pawn")
            {
                possibleMoves = new int[][]
                {
                    new int[]{0,1}
                };
            }
            if(p.name=="bishop" |p.name=="queen")
            {
                int run = 1;
                int i = k.x;
                int j = k.y;
                while ( run==1)
                {

                    i++;
                    j++;

                    if (checkOutOfBounds(i, j) == true)
                    {
                        break;
                    }
                    if(getKey(i, j).doNotUse == false)
                    {
                        moves.Add(getKey(i,j));
                    }
                }

                i = k.x;
                j = k.y;
                while (run == 1)
                {

                    i--;
                    j--;

                    if (checkOutOfBounds(i, j) == true)
                    {
                        break;
                    }
                    if (getKey(i, j).doNotUse == false)
                    {
                        moves.Add(getKey(i, j));
                    }
                }
                i = k.x;
                j = k.y;
                while (run == 1)
                {

                    i++;
                    j--;

                    if (checkOutOfBounds(i, j) == true)
                    {
                        break;
                    }
                    if (getKey(i, j).doNotUse == false)
                    {
                        moves.Add(getKey(i, j));
                    }
                }

                i = k.x;
                j = k.y;
                while (run == 1)
                {

                    i--;
                    j++;

                    if (checkOutOfBounds(i, j) == true)
                    {
                        break;
                    }
                    if (getKey(i, j).doNotUse == false)
                    {
                        moves.Add(getKey(i, j));
                    }
                }

            }

            if(p.name=="rook" |p.name=="queen")
            {

                for (int i=0;i<xBound;i++)
                {
                    //Console.WriteLine("Iteration 1 " + i);
                    if (i==k.x)
                    {
                        continue;
                    }

                    if (getKey(i, k.y).doNotUse == false)
                    {
                        moves.Add(getKey(i,k.y));
                    }

                }

                for (int i = 0; i <yBound; i++)
                {
                    //Console.WriteLine("Iteration 2 " + i);
                    if (i == k.y)
                    {
                        continue;
                    }
                    if (getKey(k.x, i).doNotUse == false)
                    {
                        moves.Add(getKey(k.x, i));
                    }
                }
            }
            if (possibleMoves!=null) 
            {
                //Console.Out.WriteLine("Get possible moves");
                foreach (int[] i in possibleMoves)
                {

                    int[] coord = addCoordinates(k.x, k.y, i);

                    if (checkOutOfBounds(coord[0], coord[1]) == false)
                    {
                        //Console.WriteLine("In bounds");
                        if (getKey(coord[0], coord[1]).doNotUse == false)
                        {
                            //Console.WriteLine("Key accessable");
                            moves.Add(getKey(coord[0], coord[1]));
                            //Console.WriteLine("Possible Move" + getKey(coord[0], coord[1]).name);
                        }

                    }

                }
            }
            return moves;
        }

        public Key getKey(int x,int y)
        {//gets key from keypad array
            Key k=keypad[x,y];
            return k;
        }
        private int[] addCoordinates(int x,int y, int addX, int addY)
        {//adds two coordinates together
            int[] coordinates= {x+addX,y+addX };
            //Console.WriteLine(coordinates[0] + " " + coordinates[1]);
            return coordinates;
        }
        private int[] addCoordinates(int x, int y, int[] add)
        {//adds two coordinates together
            int[] coordinates = { x + add[0], y + add[1] };
            //Console.WriteLine(coordinates[0] + " " + coordinates[1]);
            return coordinates;
        }
        public bool checkOutOfBounds(int x,int y)
        {//checks if array search is out of bounds, prevents exceptions
            if (x>=xBound||y>=yBound||x<0||y<0)
            {
                return true;
            }
            return false;
        }
    }
}
