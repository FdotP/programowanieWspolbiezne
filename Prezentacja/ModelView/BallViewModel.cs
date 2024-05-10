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
        private float mass;
        private float diameter;
        private List<BallViewModel> _otherBalls;

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
                - naprawic kulki bo X i Y to tak naprawde Top i Left wiec odbijanie od gornej sciany srednio dziala
                    chociaz to akurat tez moze byc jakis problem z canvasem nwm
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
            float newXVel = ballProperty.X_Velocity;
            float newYVel = ballProperty.Y_Velocity;
            // Checking X position
            if (this.XLocation + this.ballProperty.Radius >= 800 || this.XLocation - this.ballProperty.Radius <= 0) { newVelocity.X = -newXVel; }
            // Checking Y position
            if (this.YLocation + this.ballProperty.Radius >= 600 || this.YLocation - this.ballProperty.Radius <= 0) { newVelocity.Y = -newYVel; }
            ballProperty.velocityVector = newVelocity;

        }

        private void checkBallCollisionVector2D()
        {

            foreach (BallViewModel ball in this._otherBalls)
            {
                Vector2 currentBallPosition = new Vector2(this.XLocation, this.YLocation);
                Vector2 otherBallPosition = new Vector2(ball.XLocation, ball.YLocation);
                Vector2 distanceVector = otherBallPosition - currentBallPosition;
                float distance = distanceVector.Length();
                if (distance <= (ball.Radius + this.Radius))
                {
                    Trace.WriteLine("Balls collided");
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

        private void checkBallCollision()
        {
            foreach (BallViewModel ball in this._otherBalls)
            {
                // Callculating distance to other ball
                double distance = Math.Sqrt(Math.Pow(this.XLocation - ball.XLocation, 2) + Math.Pow(this.YLocation - ball.YLocation, 2));
                // Callculating distance when collision occurs to other ball
                double collideDst = this.radius + ball.Radius;
                // Checking for collision
                if (collideDst >= distance)
                {
                    Trace.WriteLine("Balls collided");
                }
            }
        }

        public void Move()
        {
            while (this != null)
            {
                Trace.WriteLine(diameter);
                this.XLocation += ballProperty.X_Velocity;
                this.YLocation += ballProperty.Y_Velocity;
                checkWallCollision();
                //checkBallCollision();
                checkBallCollisionVector2D();
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
