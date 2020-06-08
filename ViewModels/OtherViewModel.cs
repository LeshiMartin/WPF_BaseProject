using System;
using System.Collections.Generic;
using System.Text;
using BaseProject.InterFaces;
using MaterialDesignThemes.Wpf;

namespace BaseProject.ViewModels
{
    public class OtherViewModel:BaseViewModel,IViewNavigation
    {
        public string RouteName => "Other View";
        public PackIconKind Icon => PackIconKind.AbTesting;
    }
}
