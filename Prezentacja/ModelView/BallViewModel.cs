using Dane.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prezentacja.ModelView
{
    public class BallViewModel : ViewModelBase
    {
        private Ball ballProperty;
        private float xLocation;
        private float yLocation;
        private float radius;

        public BallViewModel(Ball ball)
        {
            this.ballProperty = ball;
            this.xLocation = ball.X;
            this.yLocation = ball.Y;
            this.radius = ball.Radius;
        }

        public void Move()
        {
            while (this != null)
            {
                this.XLocation += ballProperty.X_Velocity;
                this.YLocation += ballProperty.Y_Velocity;
                Thread.Sleep(10);
            }
            
        }


        public float XLocation
        {
            get
            {
                return xLocation;
            }
            set
            {

                xLocation = value;
                OnPropertyChanged(nameof(XLocation));
            }
        }

        public float YLocation
        {
            get
            {
                return yLocation;
            }
            set
            {

                yLocation = value;
                OnPropertyChanged(nameof(YLocation));
            }
        }

        public float Radius
        {
            get
            {
                return radius;
            }
            set
            {

               radius = value;
                OnPropertyChanged(nameof(Radius));
            }
        }


    }
}
