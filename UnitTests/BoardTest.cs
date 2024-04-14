using Dane.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    internal class BoardTest
    {
        [Test]
        public void constructorTest()
        {
            Board board = new Board(4);
            Assert.IsNotNull(board);
        }

        [Test]
        public void getterTest() {
            Board board = new Board(4);
            Assert.That(board.getBalls, Is.Not.Null);
        }
        [Test]
        public void setterTest() {
            Board board = new Board(4);
            Ball[] balls = new Ball[5];
            board.setBalls(balls);
            Assert.That(board.getBalls(), Is.EqualTo(balls));
        }
    }
}
