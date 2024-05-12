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

            // Dict for every ball containing references to the other balls
            Dictionary<BallViewModel, List<BallViewModel>> ballsWithoutSelf = new Dictionary<BallViewModel, List<BallViewModel>>();
            foreach (BallViewModel ball in balls)
            {
                List<BallViewModel> otherBalls = balls.Where(b => b != ball).ToList();
                ballsWithoutSelf[ball] = otherBalls;
            }
            
            foreach (BallViewModel ball in this.balls)
            {
                // Setting list of references to the other balls
                ball.OtherBalls = ballsWithoutSelf[ball];

                //Thread tBallMovement = new Thread(() =>
                //{
                //    ball.Move();
                //})
                //{
                //    Name = "ball" + ball.GetHashCode()
                //};
                //tBallMovement.Start();

                Task simulation = Task.Run(() => { ball.Move(); });
            }

        }
    }
}
