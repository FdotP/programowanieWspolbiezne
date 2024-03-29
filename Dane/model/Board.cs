using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dane.model
{
    public class Board
    {
        public Ball[] balls;
        public Board(int size) { 
            balls = new Ball[size];
        }

        public Ball[] getBalls()
        {
            return balls;
        }

        public void setBalls(Ball[] balls)
        {
            this.balls = balls;
        }
    }
}
