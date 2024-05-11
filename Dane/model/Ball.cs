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
        int diameter;
        Board board;
        public Ball(Vector2 velocity, float mass, Vector2 position, int radius, Board board) {
            this.velocity = velocity;
            this.mass = mass;
            this.position = position;
            this.radius = radius;
            this.board = board; 
            this.diameter = 2 * radius;
        }


        public float X { 
            get { return position.X; }
            set { position.X = value; }
        }

        public float Y
        {
            get { return position.Y; }
            set { position.Y = value; }
        }

        public int Radius
        { 
            get { return radius; }
            set { radius = value; }
        }

        public int Diameter { get { return diameter; } }

        public float X_Velocity { get { return velocity.X; } set { velocity.X = value; } }
        public float Y_Velocity { get { return velocity.Y; } set { velocity.Y = value; } }
        public float Mass { get { return mass; } }

        public Vector2 velocityVector
        {
            get { return velocity; } 
            set { velocity = value; }
        }

        public Vector2 positionVector
        {
            get { return position; }
            set { position = value; }
        }
    }
}
