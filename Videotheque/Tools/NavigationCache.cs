using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Videotheque.Models;

namespace Videotheque.Tools
{
    public class NavigationCache
    {
        private static Dictionary<Type, object> _viewsCache = new Dictionary<Type, object>();
        private static Dictionary<Type, Base> _ViewModelCache =
            new Dictionary<Type, Base>();

        private static TViewModel GetViewModelInstance<TViewModel>(bool createNew, params object[] viewModelParameters)
            where TViewModel : Base
        {
            return (TViewModel)GetViewModelInstance(createNew, typeof(TViewModel), viewModelParameters);
        }
        private static object GetViewModelInstance(bool createNew, Type tViewModel,
                                                   params object[] viewModelParameters)
        {
            object vm = null;
            if (_ViewModelCache.ContainsKey(tViewModel) && !createNew)
                vm = _ViewModelCache[tViewModel];
            else
            {
                vm = Activator.CreateInstance(tViewModel, viewModelParameters);
                _ViewModelCache[tViewModel] = (Base)vm;
            }
            return vm;
        }

        private static TView GetViewInstance<TView>(object viewModel, bool createNew)
            where TView : class
        {
            return (TView)GetViewInstance(createNew, typeof(TView), viewModel);
        }
        private static object GetViewInstance(bool createNew, Type tView, object viewModel)
        {
            object view = null;
            bool isWindow = tView.BaseType == typeof(Window);
            if (!isWindow && _viewsCache.ContainsKey(tView) && !createNew)
                view = _viewsCache[tView];
            else
            {
                view = Activator.CreateInstance(tView);
                var prop = tView.GetProperty("DataContext");
                prop?.SetValue(view, viewModel);
                if (!isWindow)
                    _viewsCache[tView] = view;
            }
            return view;
        }

        public static TView GetPage<TView, TViewModel>(bool createNew = false, params object[] viewModelParameters)
            where TView : Page
            where TViewModel : Base
        {
            return GetViewInstance<TView>(
                GetViewModelInstance<TViewModel>(createNew, viewModelParameters), createNew);
        }

        public static TView Show<TView, TViewModel>(bool createNew = false, params object[] viewModelParameters)
            where TView : Window
            where TViewModel : Base
        {
            var vm = GetViewModelInstance<TViewModel>(createNew, viewModelParameters);
            var view = GetViewInstance<TView>(vm, createNew);
            view.Show();
            return view;
        }
        public static void Close(Window view, bool? result = null)
        {
            if (result != null)
                view.DialogResult = result;
            view.Close();
        }

        public static bool? ShowDialog<TView, TViewModel>(bool createNew = false, params object[] viewModelParameters)
            where TView : Window
            where TViewModel : Base
        {
            var vm = GetViewModelInstance<TViewModel>(createNew, viewModelParameters);
            var view = GetViewInstance<TView>(vm, createNew);
            return view.ShowDialog();
        }
    }
}
