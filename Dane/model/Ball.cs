using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Dane.model
{
    public  class Ball
    {
        Vector2 velocity;
        float mass;
        int x, y,radius;
        public Ball(Vector2 velocity, float mass, int x, int y, int radius) {
            this.velocity = velocity;
            this.mass = mass;
            this.x = x;
            this.y = y;
            this.radius = radius;
        }   
        
    }
}
