using BaseProject.Helpers;
using BaseProject.InterFaces;
using BaseProject.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Reflection;

namespace BaseProject.Services.Implementations
{
    public class NavigationService : IWpfOnInit, INavigationService
    {
        private readonly IObjectActivator _objectActivator;
        protected Dictionary<string, TypeInfo> _DataContexts;
        protected Dictionary<string, TypeInfo> _Views;

        public NavigationService()
        {
            _objectActivator = EngineContext.Resolve<IObjectActivator>();
            OnInit();
        }

        public void OnInit()
        {
            _DataContexts = UtilityHelper.GetTypeInfos<IViewNavigation>().ToDictionary(x => x.Name, x => x);
            _Views = UtilityHelper.GetTypeInfos<INavigationView>().ToDictionary(x => x.Name, x => x);

            OnViewChanges = new Subject<INavigationView>();
            WhenViewChanges = OnViewChanges.Select(SetCurrentView).AsObservable();
        }

        public IObservable<INavigationView> WhenViewChanges { get; set; }
        protected ISubject<INavigationView> OnViewChanges { get; set; }

        public IEnumerable<string> ViewNames => _Views
                                                != null ? _Views.Select(x => x.Key) : Array.Empty<string>();
        public IEnumerable<string> DataContextNames => _DataContexts
                                                       != null ? _DataContexts.Select(x => x.Key) : Array.Empty<string>();
        protected INavigationView SetCurrentView(INavigationView view)
        {
            CurrentView = view;
            return view;
        }
        public INavigationView CurrentView { get; private set; }

        public TypeInfo FindView(string ViewName)
        {
            if (_Views.ContainsKey(ViewName)) return _Views[ViewName];
            return null;
        }

        public void Navigate(string viewName)
        {
            if (FindView(viewName) == null) return;
            var view = FindviewAndSetDataContext(viewName);
            if (view == null) return;
            OnViewChanges.OnNext(view);
        }

        protected virtual INavigationView FindviewAndSetDataContext(string viewName)
        {
            var view = _objectActivator.CreateObject<INavigationView>(FindView(viewName));
            view.Name = viewName;

            if (_DataContexts.TryGetValue(viewName.ToViewModelName(), out var DataContextType))
                view.DataContext = _objectActivator.CreateObject<IViewNavigation>(DataContextType);

            return view;
        }
    }
}
