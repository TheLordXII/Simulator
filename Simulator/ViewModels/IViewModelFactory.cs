using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.ViewModels
{
    public interface IViewModelFactory
    {
        public ViewModelBase Load();
    }
}
