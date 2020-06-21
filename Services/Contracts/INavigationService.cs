using BaseProject.InterFaces;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace BaseProject.Services.Contracts
{
    public interface INavigationService : IService
    {
        IEnumerable<string> DataContextNames { get; }
        IEnumerable<string> ViewNames { get; }
        IObservable<INavigationView> WhenViewChanges { get; set; }

        INavigationView CurrentView { get; }

        TypeInfo FindView(string ViewName);
        void Navigate(string viewName);
        void OnInit();
    }
}