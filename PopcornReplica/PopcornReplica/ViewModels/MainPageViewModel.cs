using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopcornReplica.ViewModels
{
    public class MainPageViewModel
    {

        public string Text { get; set; }


        public MainPageViewModel()
        {

            Text = "Hello World using Prism!";
            
        }
    }
}
