using Dane.model;
using Logika;
using Prezentacja.ModelView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Prezentacja.Commands
{
    internal class PassAmountOfBalls : CommandBase
    {
        private ObservableCollection<Ball>? balls;
        private amountOfBallViewModel? viewModel;
        public BallFunctions bf = new BallFunctions();

        public PassAmountOfBalls(ObservableCollection<Ball>? balls, amountOfBallViewModel am)
        {
            this.balls = balls;
            this.viewModel = am;
        }

        public override void Execute(object parameter)
        {      
            Board board = new Board(viewModel.Amount);
            for (int i = 0;i< viewModel.Amount; i++)
            {
                balls.Add(bf.generateBalls(board));
            }

        }
    }
}
