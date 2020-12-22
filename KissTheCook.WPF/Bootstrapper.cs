using Caliburn.Micro;
using Common.Controls;
using KissTheCook.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KissTheCook.WPF
{
    public class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper()
        {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
            //ConventionManager.AddElementConvention<Rate>(Rate.RatingValueProperty, "Value", "")
        }
    }
}
