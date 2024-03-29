using Dane.model;
using System;
using System.Collections.Generic;
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
            float x = random.Next(radius+10, 800-radius);
            float y = random.Next(radius + 10, 600-radius);
            int mass = random.Next(10, 100);
            Vector2 velocity = new Vector2(random.Next(5,10),random.Next(5,10));
            Vector2 position = new Vector2(x, y);
            return new Ball(velocity, mass, position, radius, board);
        }
    }
}
