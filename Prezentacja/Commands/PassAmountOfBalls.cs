using Dane.model;
using Logika;
using Prezentacja.ModelView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Prezentacja.Commands
{
    internal class PassAmountOfBalls : CommandBase
    {
        private ObservableCollection<BallViewModel>? balls;
        private amountOfBallViewModel? viewModel;
        public BallFunctions bf = new BallFunctions();

        public PassAmountOfBalls(ObservableCollection<BallViewModel>? balls, amountOfBallViewModel am)
        {
            this.balls = balls;
            this.viewModel = am;
        }

        // Metoda wywolywana na nacisniecie przycisku 
        public override void Execute(object parameter)
        {
            Trace.WriteLine("Creating board...");
            Board board = new Board(viewModel.Amount);
            Trace.WriteLine("Generating balls...");
            for (int i = 0; i < viewModel.Amount; i++)
            {
                this.balls.Add(new BallViewModel(bf.generateBalls(board)));
            }

            foreach (BallViewModel ball in this.balls)
            {
                Thread tBallMovement = new Thread(() => ball.Move());
                tBallMovement.Start();
            }

        }
    }
}
