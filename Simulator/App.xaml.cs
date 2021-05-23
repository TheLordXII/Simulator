using Simulator.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Simulator
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Simulator.MainWindow window = new MainWindow();
            MainViewModelFactory factory = new MainViewModelFactory();
            MainViewModel _viewModel;
            _viewModel = factory.Load();

            window.DataContext = _viewModel;
            window.Show();
        }
    }
}
