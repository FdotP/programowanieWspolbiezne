using Dane.model;
using Prezentacja.Model;
using Logika;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prezentacja.ModelView
{
    class boardViewModel : ViewModelBase
    {
        ObservableCollection<Ball> balls;
        public boardViewModel(int amountOfBall)
        {
            BallFunctions ballFunctions = new BallFunctions();
            balls = new ObservableCollection<Ball>();
            for (int i = 0; i < amountOfBall; i++)
            {
                balls.Add(ballFunctions.gnerateBalls());
            }    
        }
    }
}
