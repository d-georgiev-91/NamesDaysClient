using System;
using System.Collections;
using System.Linq;
using NamesDaysClient.Common;
using NamesDaysClient.ViewModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// TODO: Connect the Search Results Page to your in-app search.
// The Search Results Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234240

namespace NamesDaysClient.Pages
{
    /// <summary>
    /// This page displays search results when a global search is directed to this application.
    /// </summary>
    public sealed partial class SearchResultsPage : Page
    {
        private NavigationHelper navigationHelper;
        private SearchResultsViewModel currentModel = null;

        /// <summary>
        /// NavigationHelper is used on each page to aid in navigation and 
        /// process lifetime management
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }

        public SearchResultsPage()
        {
            this.InitializeComponent();
            this.currentModel = new SearchResultsViewModel();
            this.DataContext = this.currentModel;
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += NavigationHelperLoadState;
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="navigationParameter">The parameter value passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested.
        /// </param>
        /// <param name="pageState">A dictionary of state preserved by this page during an earlier
        /// session.  This will be null the first time a page is visited.</param>
        private void NavigationHelperLoadState(object sender, LoadStateEventArgs e)
        {
            var queryText = e.NavigationParameter as string;
            this.currentModel.QueryText = '\u201c' + queryText + '\u201d';
        }

        public void GoToHomePageClickClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(HomePage));
        }

        public void GoToNameDayNamesItemClick(object sender, ItemClickEventArgs e)
        {
            this.Frame.Navigate(typeof(NameDayNamesPage), e.ClickedItem);
        }

        #region NavigationHelper registration

        /// The methods provided in this section are simply used to allow
        /// NavigationHelper to respond to the page's navigation methods.
        /// 
        /// Page specific logic should be placed in event handlers for the  
        /// <see cref="GridCS.Common.NavigationHelper.LoadState"/>
        /// and <see cref="GridCS.Common.NavigationHelper.SaveState"/>.
        /// The navigation parameter is available in the LoadState method 
        /// in addition to page state preserved during an earlier session.

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedTo(e);
            this.Loaded += PageLoaded;
            this.Unloaded += PageUnloaded;
        }

        private void PageLoaded(object sender, RoutedEventArgs e)
        {
            Window.Current.SizeChanged += WindowSizeChanged;
        }

        private void WindowSizeChanged(object sender, Windows.UI.Core.WindowSizeChangedEventArgs e)
        {
            if (e.Size.Width <= 1000)
            {
                this.typical.Visibility = Visibility.Collapsed;
                this.snapped.Visibility = Visibility.Visible;
                this.snapped.Width = e.Size.Width;
            }
            else
            {
                this.typical.Visibility = Visibility.Visible;
                this.snapped.Visibility = Visibility.Collapsed;
            }
        }

        private void PageUnloaded(object sender, RoutedEventArgs e)
        {
            Window.Current.SizeChanged -= WindowSizeChanged;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedFrom(e);
        }

        #endregion
    }
}
