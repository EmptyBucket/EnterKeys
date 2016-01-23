using System.Windows;
using System.Windows.Input;

namespace EnterKeyes.Views
{
    public partial class OpenFileWindow : Window
    {
        public OpenFileWindow()
        {
            InitializeComponent();
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) =>
            DragMove();
    }
}
