using System.Windows;
using WeatherAPP.ViewModels.Views;

namespace WeatherAPP.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow(MainWindowVM viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
