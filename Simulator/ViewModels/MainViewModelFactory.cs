using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulator.Models;

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
            var memory = new Memory();



            
            return new MainViewModel(/* inject models for easier testing*/memory);
        }
    }
}
