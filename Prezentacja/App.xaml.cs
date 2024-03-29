using Prezentacja.ModelView;
using Prezentacja.Stores;
using System.Configuration;
using System.Data;
using System.Windows;

namespace Prezentacja
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly NavigationStore navigationStore;

        public App(){
            navigationStore = new NavigationStore();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            navigationStore.CurrentViewModel = new amountOfBallViewModel(navigationStore);
            MainWindow = new MainWindow()
            {
                DataContext = new MainModelView(navigationStore)
            };
            MainWindow.Show();
            base.OnStartup(e);
        }
    }

}
