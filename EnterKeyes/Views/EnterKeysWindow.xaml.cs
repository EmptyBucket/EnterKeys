using System.Windows;
using System.Windows.Input;

namespace EnterKeyes.Views
{
    public partial class EnterKeysWindow : Window
    {
        public EnterKeysWindow()
        {
            InitializeComponent();
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) =>
            DragMove();
    }
}
