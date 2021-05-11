using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace KeyChess
{
    class Simulation
    {
        private const String pieceFilePath = "Data/pieces.json";
        private const String keypadFilePath = "Data/keypad.json";
        private const String walkFilePath = "Data/walk.json";

        private Keypad keypad = new Keypad();

        private List<Key> startingKeys = new List<Key>();
        List<Piece> pieces = new List<Piece>();
        private List<Key> number=new List<Key>();
        private int numLength=0;
        private Piece piece=new Piece();
        private bool consoleOutput;
        public Simulation()
        {
            initKeypad();
        }

        public void run()
        {
            //intit keypad from json

            //Key k=keypad.getKey(1,1);
            //List<Key> output=keypad.getPossibleMoves(k);

            walk();

        }


        private void walk()
        {
            Console.WriteLine("start walk");
            //get keys to start from

            int[][] startkey =
            {
                    new int[]{0,1},
                    new int[]{1,1},
                    new int[]{2,1},
                    new int[]{0,2},
                    new int[]{1,2},
                    new int[]{2,2},
                    new int[]{1,3},
                    new int[]{2,3}
            };
            foreach (int[]startingNumbers in startkey)
            {
                startingKeys.Add(keypad.getKey(startingNumbers[0],startingNumbers[1]));
            }

            //use stack to get all keys

            StackManager s = new StackManager(startingKeys,keypad,piece,numLength,consoleOutput);
            s.run();


        }
        public void inputPiece(String s)
        {
            piece.name = s;
        }
        public void inputNumLength(int n)
        {
            this.numLength = n;
        }

        public void consoleOut(bool input)
        {
            consoleOutput = input;
        }
        private void initPieces()
        {
            String jsonString = File.ReadAllText(pieceFilePath);
            JsonSerializer.Deserialize<Piece[]>(jsonString);

        }
        private void initKeypad()
        {
            String jsonString= File.ReadAllText(keypadFilePath);
            KeyArray keyArray = new KeyArray();

            keyArray.keys = JsonSerializer.Deserialize<Key[]>(jsonString);
            keypad.populateKeypad(keyArray);

        }

        private bool verifyPieces()
        {//verify objects and try to catch errors
            return true;
        }
        private bool verifyKeypad(Keypad keypad)
        {//verify objects and try to catch errors
            return true;
        }
    }
}
