using Dane.model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Prezentacja.ModelView
{
    public class BallViewModel : ViewModelBase
    {
        private Ball ballProperty;
        private float xLocation;
        private float yLocation;
        private float radius;

        public BallViewModel(Ball ball)
        {
            this.ballProperty = ball;
            this.xLocation = ball.X;
            this.yLocation = ball.Y;
            this.radius = ball.Radius;
        }

        private void printPos()
        {
            Trace.WriteLine("X: " + this.XLocation + ", Y: " + this.YLocation); 
        }

        private void checkWallCollision()
        {
            Vector2 newVelocity = new Vector2(ballProperty.X_Velocity, ballProperty.Y_Velocity);
            float newXVel = ballProperty.X_Velocity;
            float newYVel = ballProperty.Y_Velocity;
            // Checking X position
            if (this.XLocation + this.radius >= 800 || this.XLocation - this.radius <= 0) { newVelocity.X = -newXVel; }
            if (this.YLocation + this.radius >= 600 || this.YLocation - this.radius <= 0) { newVelocity.Y = -newYVel;}
            ballProperty.velocityVector = newVelocity;

        }

        public void Move()
        {
            while (this != null)
            {
                this.XLocation += ballProperty.X_Velocity;
                this.YLocation += ballProperty.Y_Velocity;
                checkWallCollision();
                Thread.Sleep(10);
            }
            
        }


        public float XLocation
        {
            get
            {
                return xLocation;
            }
            set
            {

                xLocation = value;
                OnPropertyChanged(nameof(XLocation));
            }
        }

        public float YLocation
        {
            get
            {
                return yLocation;
            }
            set
            {

                yLocation = value;
                OnPropertyChanged(nameof(YLocation));
            }
        }

        public float Radius
        {
            get
            {
                return radius;
            }
            set
            {

               radius = value;
                OnPropertyChanged(nameof(Radius));
            }
        }


    }
}
