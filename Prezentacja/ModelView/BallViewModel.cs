using Dane.model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;

namespace Prezentacja.ModelView
{
    public class BallViewModel : ViewModelBase
    {
        private Ball ballProperty;
        private float xLocation;
        private float yLocation;
        private float radius;
        //private float mass;
        private float diameter;
        private List<BallViewModel> _otherBalls;
        static readonly object locker = new object();

        public List<BallViewModel> OtherBalls { get { return _otherBalls; } set { _otherBalls = value; } }

        public BallViewModel(Ball ball)
        {
            // Original ball's properties
            this.ballProperty = ball;

            // Binded values
            this.xLocation = ball.X;
            this.yLocation = ball.Y;
            this.radius = ball.Radius;
            this.diameter = ball.Diameter;

        }

        private void checkWallCollision()
        {
            Vector2 newVelocity = new Vector2(ballProperty.X_Velocity, ballProperty.Y_Velocity);
            //float newXVel = ballProperty.X_Velocity;
            //float newYVel = ballProperty.Y_Velocity;
            float newX = this.XLocation + ballProperty.X_Velocity;
            float newY = this.YLocation + ballProperty.Y_Velocity;

            // XLocation and YLocation mark the top-left corner of ball)
            // Math.Clamp() tries to prevent balls from beeing "sucked" into the walls
            
            // Checking X position (left and right walls collision)
            if (this.XLocation + this.ballProperty.Diameter >= 800 || this.XLocation <= 0)
            {  
                newVelocity.X = -ballProperty.X_Velocity;
                newX = Math.Clamp(newX, 0, 800 - this.ballProperty.Diameter);
            }
            // Checking Y position (top and botttom walls collision)
            if (this.YLocation + this.ballProperty.Diameter >= 600 || this.YLocation <= 0) 
            { 
                newVelocity.Y = -ballProperty.Y_Velocity;
                newY = Math.Clamp(newY, 0, 600 - this.ballProperty.Diameter);
            }
            ballProperty.velocityVector = newVelocity;
            this.XLocation = newX;
            this.YLocation = newY;

        }


        public void checkBallsCollision()
        {
            foreach (BallViewModel ball in this._otherBalls)
            {
                lock (locker)
                {
                    Vector2 currentBallPosition = new Vector2(this.XLocation, this.YLocation);
                    Vector2 otherBallPosition = new Vector2(ball.XLocation, ball.YLocation);
                    Vector2 distanceVector = otherBallPosition - currentBallPosition;
                    float dst = distanceVector.Length();
                    if (dst <= (ball.Radius + this.Radius) && dst > 0)
                    {
                        Vector2 difference = currentBallPosition - otherBallPosition;
                        float distance = difference.Length();

                        // Callculating collission vector
                        Vector2 collisionVector = Vector2.Normalize(currentBallPosition - otherBallPosition);

                        // Callculating speed along collision
                        float velocityAlongCollision = Vector2.Dot(this.ballProperty.velocityVector - ball.ballProperty.velocityVector, collisionVector);

                        // Return, if velocity points in other direction
                        if (velocityAlongCollision > 0)
                        {
                            return;
                        }

                        // Callculating impulse to avoid balls spinning around each other
                        float impulse = -(1 + 1) * velocityAlongCollision / (1 / this.ballProperty.Mass + 1 / ball.ballProperty.Mass);
                        Vector2 impulseVector = impulse * collisionVector;

                        this.ballProperty.velocityVector +=  (1 / this.ballProperty.Mass) * impulseVector;
                        ball.ballProperty.velocityVector -=  (1 / ball.ballProperty.Mass) * impulseVector;
                    }
                }
            }
             
        }


        // method executed asynchronously for each object
        // single task (thread) for every object
        public void Move()
        {
            while (this != null)
            {
                this.XLocation += ballProperty.X_Velocity;
                this.YLocation += ballProperty.Y_Velocity;
                checkWallCollision();
                checkBallsCollision();
                Thread.Sleep(20);
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

        public float Diameter
        {
            get { return diameter; }
            set { diameter = value; OnPropertyChanged(nameof(Diameter)); }
        }
    }
}
