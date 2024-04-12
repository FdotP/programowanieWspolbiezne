using Dane.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    internal class BallTests
    {
        Board board = new Board(1);
        Vector2 position = new Vector2(1.0f, 1.0f);
        Vector2 velocity = new Vector2(0.4f, 1.0f);
        [Test]
        public void createBall()
        {
            Ball ball = new Ball(velocity, 3.5f, position, 5, board);
            Assert.IsNotNull(ball);
            Assert.That(ball.Radius, Is.EqualTo(5));
            Assert.That(ball.X, Is.EqualTo(1.0f));  
            Assert.That(ball.Y, Is.EqualTo(1.0f));
            Assert.That(ball.Mass, Is.EqualTo(3.5f));
            Assert.That(ball.X_Velocity, Is.EqualTo(0.4f));
            Assert.That(ball.Y_Velocity, Is.EqualTo(1.0f));
        }
    }
}
