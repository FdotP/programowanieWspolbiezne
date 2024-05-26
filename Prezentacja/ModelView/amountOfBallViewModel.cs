using Dane.model;
using Logika;
using Prezentacja.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Shapes;
using Timer = System.Timers.Timer;

namespace Prezentacja.ModelView
{
    class amountOfBallViewModel : ViewModelBase
    {
        Board board;
        BallFunctions ballFunctions = new BallFunctions();
        ObservableCollection<BallViewModel> balls;
        private static System.Timers.Timer aTimer;
        static string workingDirectory = Environment.CurrentDirectory;
        static string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
        string path = projectDirectory += "\\test.txt";
        public amountOfBallViewModel(Stores.NavigationStore navigationStore) {
            balls = new ObservableCollection<BallViewModel>();
            submitCommand = new PassAmountOfBalls(generatedBalls, this);
            board = new Board(amount);


            // Create a timer with a two second interval.
            aTimer = new System.Timers.Timer(2000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += DisplayTimeEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
            

            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("logs");
                }
            }
            else
            {
                StreamWriter sw = new StreamWriter(path);
                sw.WriteLine("logs");
                sw.Close();
            }
            


        }

        public void DisplayTimeEvent(object source, ElapsedEventArgs e)
        {
            DateTime dateValue = DateTime.Now;
            Trace.WriteLine(dateValue.ToString("MM/dd/yyyy hh:mm:ss.fff tt"));
            
            Trace.WriteLine(projectDirectory);

            if (balls.Count != 0)
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(dateValue.ToString("MM/dd/yyyy hh:mm:ss.fff tt"));
                    foreach (BallViewModel ball in balls)
                    {
                        
                        sw.WriteLine("x location: " + ball.XLocation + ", y location: " + ball.YLocation+" " + ball.GetHashCode());
                    }
                    
                }
            }
        }

       
    


        private int amount;

        public int Amount {
            get {
                return amount;
            }
            set
            {
   
                amount = value;
                OnPropertyChanged(nameof(Amount));
            }
        }

         
        public ObservableCollection<BallViewModel> generatedBalls
        {
            get
            {
                return balls;
            }
            set
            {
                MessageBox.Show("Unable to...");
                balls = value;
                OnPropertyChanged(nameof(generatedBalls));
            }
        }

        public ICommand submitCommand { get; }


    }
}
