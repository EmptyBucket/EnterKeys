using System.Windows;
using GalaSoft.MvvmLight.Threading;

namespace EnterKeyes
{
    public partial class App : Application
    {
        static App()
        {
            DispatcherHelper.Initialize();
        }
    }
}
