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
        //private float mass;
        private float diameter;
        private List<BallViewModel> _otherBalls;
        static readonly object locker = new object();
        readonly object instanceLocker = new object();

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
            
            /*  TODO
                - naprawic odbijanie sie kulek bo czasem wpadaja w zaiwrowania xd
                - jakies sekcje krytyczne czy cos moze???
             */
        }

        private void printPos()
        {
            Trace.WriteLine("X: " + this.XLocation + ", Y: " + this.YLocation);
        }

        private void checkWallCollision()
        {
            Vector2 newVelocity = new Vector2(ballProperty.X_Velocity, ballProperty.Y_Velocity);
            //float newXVel = ballProperty.X_Velocity;
            //float newYVel = ballProperty.Y_Velocity;
            float newX = this.XLocation + ballProperty.X_Velocity;
            float newY = this.YLocation + ballProperty.Y_Velocity;

            // XLocation and YLocation mark the top-left corner of ball)
            // Checking X position (left and right walls collision)
            // Math.Clamp() tries to prevent balls from beeing "sucked" into the walls
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

        private void checkBallCollisionVector2D()
        {

            foreach (BallViewModel ball in this._otherBalls)
            {
                //lock (ball)??(this)??(locker)???
                lock (locker) { 
                    Vector2 currentBallPosition = new Vector2(this.XLocation, this.YLocation);
                    Vector2 otherBallPosition = new Vector2(ball.XLocation, ball.YLocation);
                    Vector2 distanceVector = otherBallPosition - currentBallPosition;
                    float distance = distanceVector.Length();
                    if (distance <= (ball.Radius + this.Radius) && distance > 0)
                    {
                        //Trace.WriteLine("Balls collided");
                        Vector2 collisionVector1 = otherBallPosition - currentBallPosition;
                        //collisionVector.Normalize();
                        Vector2 collisionVector = Vector2.Normalize(collisionVector1);

                        float initialVelocity1 = Vector2.Dot(this.ballProperty.velocityVector, collisionVector);
                        float initialVelocity2 = Vector2.Dot(ball.ballProperty.velocityVector, collisionVector);

                        float finalVelocity1 = (initialVelocity1 * (this.ballProperty.Mass - ball.ballProperty.Mass)
                            + 2 * ball.ballProperty.Mass * initialVelocity2) / (this.ballProperty.Mass + ball.ballProperty.Mass);
                        float finalVelocity2 = (initialVelocity2 * (ball.ballProperty.Mass - this.ballProperty.Mass)
                            + 2 * this.ballProperty.Mass * initialVelocity1) / (this.ballProperty.Mass + ball.ballProperty.Mass);

                        this.ballProperty.velocityVector += (finalVelocity1 - initialVelocity1) * collisionVector;
                        ball.ballProperty.velocityVector += (finalVelocity2 - initialVelocity2) * collisionVector;
                    }

                }
            }

        }

        public void ResolveCollision()
        {
            foreach (BallViewModel ball in this._otherBalls)
            {
                //lock (ball)??(this)??(locker)???
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


        public void Move()
        {
            while (this != null)
            {
                this.XLocation += ballProperty.X_Velocity;
                this.YLocation += ballProperty.Y_Velocity;
                checkWallCollision();
                //checkBallCollision();
                //checkBallCollisionVector2D();
                ResolveCollision();
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

        public float Diameter
        {
            get { return diameter; }
            set { diameter = value; OnPropertyChanged(nameof(Diameter)); }
        }
    }
}
