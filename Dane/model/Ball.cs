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
        Vector2 velocity, position;
        float mass;
        int radius;
        public Ball(Vector2 velocity, float mass, Vector2 position, int radius) {
            this.velocity = velocity;
            this.mass = mass;
            this.position = position;
            this.radius = radius;
        }   
        
    }
}
