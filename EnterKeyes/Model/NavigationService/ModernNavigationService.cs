using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace EnterKeyes.Model.NavigationService
{
    public class ModernNavigationService : IModernNavigationService
    {
        private readonly Dictionary<string, Uri> mPagesByKey;
        private readonly List<string> mHistoric;

        public ModernNavigationService()
        {
            mPagesByKey = new Dictionary<string, Uri>();
            mHistoric = new List<string>();
        }

        public string CurrentPageKey { get; private set; }

        public object Parameter { get; private set; }

        public void GoBack()
        {
            if (mHistoric.Count > 1)
            {
                mHistoric.RemoveAt(mHistoric.Count - 1);
                NavigateTo(mHistoric.Last(), null);
            }
        }

        public void NavigateTo(string pageKey)
        {
            NavigateTo(pageKey, null);
        }

        public virtual void NavigateTo(string pageKey, object parameter)
        {
            lock (mPagesByKey)
            {
                if (!mPagesByKey.ContainsKey(pageKey))
                    throw new ArgumentException(string.Format("No such page: {0}. Did you forget to call NavigationService.Configure?", pageKey), "pageKey");

                var frame = GetDescendantFromName(Application.Current.MainWindow, "ContentFrame") as ModernFrame;

                if (frame != null)
                    frame.Source = mPagesByKey[pageKey];

                Parameter = parameter;
                mHistoric.Add(pageKey);
                CurrentPageKey = pageKey;
            }
        }

        public void Configure(string key, Uri pageType)
        {
            lock (mPagesByKey)
            {
                if (mPagesByKey.ContainsKey(key))
                    mPagesByKey[key] = pageType;
                else
                    mPagesByKey.Add(key, pageType);
            }
        }

        private static FrameworkElement GetDescendantFromName(DependencyObject parent, string name)
        {
            var count = VisualTreeHelper.GetChildrenCount(parent);

            if (count < 1)
                return null;

            for (var i = 0; i < count; i++)
            {
                var frameworkElement = VisualTreeHelper.GetChild(parent, i) as FrameworkElement;
                if (frameworkElement != null)
                {
                    if (frameworkElement.Name == name)
                        return frameworkElement;

                    frameworkElement = GetDescendantFromName(frameworkElement, name);

                    if (frameworkElement != null)
                        return frameworkElement;
                }
            }

            return null;
        }
    }
}
