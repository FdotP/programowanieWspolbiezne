using Dane.model;
using Logika;
using Prezentacja.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Prezentacja.ModelView
{
    class amountOfBallViewModel : ViewModelBase
    {
        Board board;
        BallFunctions ballFunctions = new BallFunctions();
        ObservableCollection<Ball> sampleData;
        public amountOfBallViewModel(Stores.NavigationStore navigationStore) {
            sampleData= new ObservableCollection<Ball>();
            submitCommand = new PassAmountOfBalls(SampleData, this);
            board = new Board(amount);
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

         
        public ObservableCollection<Ball> SampleData
        {
            get
            {
                return sampleData;
            }
            set
            {
                MessageBox.Show("Unable to save file, try again.");
                sampleData = value;
                OnPropertyChanged(nameof(SampleData));
            }
        }

        public ICommand submitCommand { get; }

    }
}
