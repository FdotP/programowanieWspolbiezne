using Dane.model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Logika
{
    public class BallFunctions
    {
        
        public Ball generateBalls(Board board)
        { 
            Random random = new Random();
            int radius = random.Next(10, 20);
            float x = random.Next(radius + 10, 760 - radius);
            float y = random.Next(radius + 10, 560 - radius);
            //int mass = random.Next(10, 100);
            int mass = radius * 2;
            Vector2 velocity = new Vector2((float)((random.NextDouble()*6)-3), (float)(random.NextDouble() * 6) - 3);
            Vector2 position = new Vector2(x, y);
            return new Ball(velocity, mass, position, radius, board);
        }

        
    }
}
