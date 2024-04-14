using Dane.model;
using Logika;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    internal class BallFunctionsTest
    {
        [Test]
        public void constructorTest()
        {
            Board board = new Board(1);
            BallFunctions bf = new BallFunctions();
            Assert.IsNotNull(bf.generateBalls(board));
        }
    }
}
