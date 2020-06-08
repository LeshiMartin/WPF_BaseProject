using System;
using System.Collections.Generic;
using System.Text;
using BaseProject.InterFaces;
using MaterialDesignThemes.Wpf;

namespace BaseProject.ViewModels
{
    public class HomeViewModel:BaseViewModel,IViewNavigation
    {
        public string RouteName => "Home View";
        public PackIconKind Icon => PackIconKind.Home;
    }
}
