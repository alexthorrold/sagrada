﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Sagrada
{
    public abstract class BoardPiece
    {
        public const int DICE_SIZE = 45;
        public const int PEN_THICKNESS = 5;
        public const int ROUNDS = 10;

        protected int left;
        protected int top;

        public int Left
        {
            get { return left; }
            set { left = value; }
        }

        public int Top
        {
            get { return top; }
            set { top = value; }
        }

        //public abstract bool IsMouseOn(int x, int y);

        public abstract void Draw(Graphics paper);
    }
}
