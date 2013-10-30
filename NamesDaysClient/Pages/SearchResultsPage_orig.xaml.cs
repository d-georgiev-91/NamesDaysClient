using System;
using System.Collections.Generic;
using System.Linq;
using NamesDaysClient.Common;
using NamesDaysClient.ViewModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Search Contract item template is documented at http://go.microsoft.com/fwlink/?LinkId=234240

namespace NamesDaysClient.Pages
{
    public sealed partial class SearchResultsPage_orig : LayoutAwarePage
    {
        private SearchResultsViewModel currentModel = null;

        public SearchResultsPage_orig()
        {
            this.InitializeComponent();
            this.currentModel = new SearchResultsViewModel();
            this.DataContext = this.currentModel;
        }

        public void GoToHomePageClickClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(HomePage));
        }

        public void GoToNameDayNamesItemClick(object sender, ItemClickEventArgs e)
        {
            this.Frame.Navigate(typeof(NameDayNamesPage), e.ClickedItem);
        }

        public void OnPageLoaded(object sender, RoutedEventArgs e)
        {
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
        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
            var queryText = navigationParameter as String;
            this.currentModel.QueryText = '\u201c' + queryText + '\u201d';
        }
        ///// <summary>
        ///// Invoked when a filter is selected using the ComboBox in snapped view state.
        ///// </summary>
        ///// <param name="sender">The ComboBox instance.</param>
        ///// <param name="e">Event data describing how the selected filter was changed.</param>
        //void Filter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    // Determine what filter was selected
        //    var selectedFilter = e.AddedItems.FirstOrDefault() as Filter;
        //    if (selectedFilter != null)
        //    {
        //        // Mirror the results into the corresponding Filter object to allow the
        //        // RadioButton representation used when not snapped to reflect the change
        //        selectedFilter.Active = true;
        //        // TODO: Respond to the change in active filter by setting this.DefaultViewModel["Results"]
        //        //       to a collection of items with bindable Image, Title, Subtitle, and Description properties
        //        // Ensure results are found
        //        object results;
        //        ICollection resultsCollection;
        //        if (this.DefaultViewModel.TryGetValue("Results", out results) &&
        //            (resultsCollection = results as ICollection) != null &&
        //            resultsCollection.Count != 0)
        //        {
        //            VisualStateManager.GoToState(this, "ResultsFound", true);
        //            return;
        //        }
        //    }
        //    // Display informational text when there are no search results.
        //    VisualStateManager.GoToState(this, "NoResultsFound", true);
        //}
    }
}