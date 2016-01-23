using System;
using EnterKeyes.Model.NavigationService;
using GalaSoft.MvvmLight.Views;
using Ninject.Modules;

namespace EnterKeyes.ViewModel
{
    public class MainModule : NinjectModule
    {
        public override void Load()
        {
            var navigationService = new ModernNavigationService();
            navigationService.Configure(ViewModelLocator.OpenFilePage, new Uri("Views/OpenFileWindow.xaml"));
            navigationService.Configure(ViewModelLocator.EnterKeysPageKey, new Uri("Views/EnterKeysWindow.xaml"));
            Bind<INavigationService>().ToConstant(navigationService);
        }
    }
}
