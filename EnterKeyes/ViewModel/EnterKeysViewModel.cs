using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;

namespace EnterKeyes.ViewModel
{
    public class EnterKeysViewModel : ViewModelBase
    {
        public RelayCommand BackCommand { get; }
        public RelayCommand ExitCommand { get; }

        public EnterKeysViewModel(INavigationService navigationService)
        {
            BackCommand = new RelayCommand(() => navigationService.GoBack());
            ExitCommand = new RelayCommand(() => Environment.Exit(0));
        }
    }
}