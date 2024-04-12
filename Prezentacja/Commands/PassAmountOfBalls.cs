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
        private ObservableCollection<Ball>? balls;
        private amountOfBallViewModel? viewModel;
        public BallFunctions bf = new BallFunctions();

        public PassAmountOfBalls(ObservableCollection<Ball>? balls, amountOfBallViewModel am)
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
                balls.Add(bf.generateBalls(board));
            }

            foreach (Ball ball in balls)
            {
                Thread tBallMovement = new Thread(() => bf.Move(ball));
                tBallMovement.Start();
            }

            Task.Run(() =>
            {
                while (true)
                {
                    foreach (Ball ball in balls)
                    {
                        Trace.WriteLine($"Ball {ball}: ({ball.X}, {ball.Y})");
                    }
                    Thread.Sleep(1000);
                }
            });
        }
    }
}
