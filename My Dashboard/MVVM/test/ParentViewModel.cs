using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Dashboard.MVVM.test
{
    public partial class ParentViewModel : ObservableObject
    {
        [ObservableProperty]
        private string textToShow = "Hello from ViewModel with CommunityToolkit!";
    }
}
