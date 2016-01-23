using System;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Views;
using Microsoft.Win32;

namespace EnterKeyes.ViewModel
{
    public class OpenFileViewModel : ViewModelBase
    {
        public string Path { get; set; }

        public RelayCommand OverviewCommand { get; }
        public RelayCommand OpenCommand { get; }
        public RelayCommand ExitCommand { get; }

        public OpenFileViewModel(INavigationService navigationService)
        {
            OverviewCommand = new RelayCommand(() =>
            {
                var fileDialog = new OpenFileDialog();
                fileDialog.Filter = "Text Files (*.txt)|*.txt";
                fileDialog.DefaultExt = ".txt";
                if (fileDialog.ShowDialog() == true)
                    Path = fileDialog.FileName;
            });
            OpenCommand = new RelayCommand(() =>
            {
                if (System.IO.Path.GetExtension(Path) == ".txt")
                    navigationService.NavigateTo(ViewModelLocator.EnterKeysPageKey);
                else
                    MessageBox.Show("File is not txt format");
            });
            ExitCommand = new RelayCommand(() => Environment.Exit(0));
        }
    }
}