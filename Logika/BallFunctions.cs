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
        
        public Ball gnerateBalls()
        { 
            Random random = new Random();
            int radius = random.Next(50, 150);
            int x = random.Next(radius+10, 900-radius);
            int y = random.Next(radius + 10, 900-radius);
            int mass = random.Next(10, 100);
            Vector2 vector2 = new Vector2(random.Next(5,10),random.Next(5,10));
            return new Ball(vector2, mass, x, y, radius);
        }
    }
}
