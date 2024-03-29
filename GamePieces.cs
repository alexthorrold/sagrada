﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Sagrada
{
    public class GamePieces
    {
        private List<Dice> diceList;
        private List<Tile[,]> windowList;
        private List<Color> privColorList;
        private List<int> usedObjectiveIndex;

        private int diceIndex = 0;
        private int windowIndex = 0;
        private int colorIndex = 0;

        public GamePieces()
        {
            usedObjectiveIndex = new List<int>();
            
            diceList = new List<Dice>();

            //Adds the 90 dice to the list of dice
            for (int i = 0; i < 18; i++)
            {
                diceList.Add(new Dice(Color.Red, i % 6 + 1));
            }
            for (int i = 0; i < 18; i++)
            {
                diceList.Add(new Dice(Color.Blue, i % 6 + 1));
            }
            for (int i = 0; i < 18; i++)
            {
                diceList.Add(new Dice(Color.Green, i % 6 + 1));
            }
            for (int i = 0; i < 18; i++)
            {
                diceList.Add(new Dice(Color.Purple, i % 6 + 1));
            }
            for (int i = 0; i < 18; i++)
            {
                diceList.Add(new Dice(Color.Yellow, i % 6 + 1));
            }

            windowList = new List<Tile[,]>();

            windowList.Add(new Tile[5, 4]);

            for (int a = 0; a < WindowPattern.ROWS; a++)
            {
                for (int b = 0; b < windowList[0].GetLength(1); b++)
                {
                    windowList[0][a, b] = new Tile();
                }
            }

            //windowList[0][2, 0] = new Tile(Color.Green);
            //windowList[0][0, 1] = new Tile(2);
            //windowList[0][1, 1] = new Tile(Color.Yellow);
            //windowList[0][2, 1] = new Tile(5);
            //windowList[0][3, 1] = new Tile(Color.Blue);
            //windowList[0][4, 1] = new Tile(1);
            //windowList[0][1, 2] = new Tile(Color.Red);
            //windowList[0][2, 2] = new Tile(3);
            //windowList[0][3, 2] = new Tile(Color.Purple);
            //windowList[0][0, 3] = new Tile(1);
            //windowList[0][2, 3] = new Tile(6);
            //windowList[0][4, 3] = new Tile(4);

            windowList.Add(new Tile[5, 4]);

            for (int a = 0; a < WindowPattern.ROWS; a++)
            {
                for (int b = 0; b < WindowPattern.COLUMNS; b++)
                {
                    windowList[1][a, b] = new Tile();
                }
            }

            windowList[1][1, 0] = new Tile(Color.Blue);
            windowList[1][2, 0] = new Tile(Color.Red);
            windowList[1][1, 1] = new Tile(4);
            windowList[1][2, 1] = new Tile(5);
            windowList[1][4, 1] = new Tile(Color.Blue);
            windowList[1][0, 2] = new Tile(Color.Blue);
            windowList[1][1, 2] = new Tile(2);
            windowList[1][3, 2] = new Tile(Color.Red);
            windowList[1][4, 2] = new Tile(5);
            windowList[1][0, 3] = new Tile(6);
            windowList[1][1, 3] = new Tile(Color.Red);
            windowList[1][2, 3] = new Tile(3);
            windowList[1][3, 3] = new Tile(1);

            windowList.Add(new Tile[5, 4]);

            for (int a = 0; a < WindowPattern.ROWS; a++)
            {
                for (int b = 0; b < WindowPattern.COLUMNS; b++)
                {
                    windowList[2][a, b] = new Tile();
                }
            }

            windowList[2][2, 0] = new Tile(1);
            windowList[2][0, 1] = new Tile(1);
            windowList[2][1, 1] = new Tile(Color.Green);
            windowList[2][2, 1] = new Tile(3);
            windowList[2][3, 1] = new Tile(Color.Blue);
            windowList[2][4, 1] = new Tile(2);
            windowList[2][0, 2] = new Tile(Color.Blue);
            windowList[2][1, 2] = new Tile(5);
            windowList[2][2, 2] = new Tile(4);
            windowList[2][3, 2] = new Tile(6);
            windowList[2][4, 2] = new Tile(Color.Green);
            windowList[2][1, 3] = new Tile(Color.Blue);
            windowList[2][2, 3] = new Tile(5);
            windowList[2][3, 3] = new Tile(Color.Green);

            windowList.Add(new Tile[5, 4]);

            for (int a = 0; a < WindowPattern.ROWS; a++)
            {
                for (int b = 0; b < WindowPattern.COLUMNS; b++)
                {
                    windowList[3][a, b] = new Tile();
                }
            }

            windowList[3][0, 0] = new Tile(2);
            windowList[3][2, 0] = new Tile(5);
            windowList[3][4, 0] = new Tile(1);
            windowList[3][0, 1] = new Tile(Color.Yellow);
            windowList[3][1, 1] = new Tile(6);
            windowList[3][2, 1] = new Tile(Color.Pink);
            windowList[3][3, 1] = new Tile(2);
            windowList[3][4, 1] = new Tile(Color.Red);
            windowList[3][1, 2] = new Tile(Color.Blue);
            windowList[3][2, 2] = new Tile(4);
            windowList[3][3, 2] = new Tile(Color.Green);
            windowList[3][1, 3] = new Tile(3);
            windowList[3][3, 3] = new Tile(5);

            privColorList = new List<Color> { Color.Yellow, Color.Red, Color.Purple, Color.Green, Color.Blue };

            RandomiseOrder();
        }

        public void RandomiseOrder()
        {
            List<Dice> randomDice = new List<Dice>();
            int n = 90;
            int r;
            Random rand = new Random();

            while (n > 0)
            {
                r = rand.Next(n);
                randomDice.Add(diceList[r]);
                diceList.RemoveAt(r);
                n--;
            }

            diceList = randomDice;

            List<Tile[,]> randomWindows = new List<Tile[,]>();
            n = windowList.Count;

            while (n > 0)
            {
                r = rand.Next(n);
                randomWindows.Add(windowList[r]);
                windowList.RemoveAt(r);
                n--;
            }

            windowList = randomWindows;

            List<Color> randomColors = new List<Color>();
            n = privColorList.Count;

            while (n > 0)
            {
                r = rand.Next(n);
                randomColors.Add(privColorList[r]);
                privColorList.RemoveAt(r);
                n--;
            }

            privColorList = randomColors;
        }

        public Dice GetDice()
        {
            Dice d = diceList[diceIndex];
            diceIndex++;
            return d;
        }

        public Tile[,] GetNextRequirements()
        {
            windowIndex++;
            return windowList[windowIndex % 4];
        }

        public Tile[,] GetPreviousRequirements()
        {
            windowIndex--;
            return windowList[windowIndex % 4];
        }

        public ObjectiveCard GetPrivateCard(int x, int y)
        {
            ColorSumCard card = new ColorSumCard(privColorList[colorIndex], x, y);
            colorIndex++;

            return card;
        }

        public ObjectiveCard GetPublicCard(int x, int y)
        {
            Random rand = new Random();
            int i = rand.Next(9);
            ObjectiveCard obj;

            //Prevents the same card from being returned twice
            while (usedObjectiveIndex.Contains(i))
                i = rand.Next(9);

            usedObjectiveIndex.Add(i);

            //Returns a random public card
            switch (i)
            {
                case 0:
                    obj = new ColorVarietyCard(x, y);
                    break;
                case 1:
                    obj = new ColumnColorVarietyCard(x, y);
                    break;
                case 2:
                    obj = new ColumnShadeVarietyCard(x, y);
                    break;
                case 3:
                    obj = new RowColorVarietyCard(x, y);
                    break;
                case 4:
                    obj = new RowShadeVarietyCard(x, y);
                    break;
                case 5:
                    obj = new ShadeVarietyCard(x, y);
                    break;
                case 6:
                    obj = new ShadesCard("light", x, y);
                    break;
                case 7:
                    obj = new ShadesCard("medium", x, y);
                    break;
                default:
                    obj = new ShadesCard("deep", x, y);
                    break;
            }

            return obj;
        }
    }
}
