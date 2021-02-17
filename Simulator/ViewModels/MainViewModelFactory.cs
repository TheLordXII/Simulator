using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.ViewModels
{
    class MainViewModelFactory : IViewModelFactory
    {
        /// <summary>
        /// Creates a MainViewModel and needed Models for it. 
        /// </summary>
        /// <returns></returns>
        public ViewModelBase Load()
        {
            // build models





            return new MainViewModel(/* inject models for easier testing*/);
        }
    }
}
