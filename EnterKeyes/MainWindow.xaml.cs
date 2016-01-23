using System.Windows;
using EnterKeyes.ViewModel;

namespace EnterKeyes
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Closing += (s, e) => ViewModelLocator.Cleanup();
        }

        private void Grid_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e) =>
            DragMove();
    }
}