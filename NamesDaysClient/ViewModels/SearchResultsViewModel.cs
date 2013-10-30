namespace NamesDaysClient.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Net;
    using NamesDaysClient.Common;
    using NamesDaysClient.Helpers;
    using NamesDaysClient.Model;
    using Windows.UI.Popups;

    public class SearchResultsViewModel : BindableBase
    {
        private bool areResultsEmpty;

        public bool AreResultsEmpty
        {
            get
            {
                return areResultsEmpty;
            }
            set
            {
                areResultsEmpty = value;
                this.OnPropertyChanged("AreResultsEmpty");
            }
        }

        private string queryText;

        public string QueryText
        {
            get
            {
                return queryText;
            }
            set
            {
                queryText = value;
                this.OnPropertyChanged("QueryText");
                this.LoadResultsAsync();
            }
        }

        public SearchResultsViewModel()
        {
            this.AreResultsEmpty = false;
        }

        private async void LoadResultsAsync()
        {
            try
            {
                this.Results = await DataPersister.GetName(this.QueryText.Replace('\u201c', '\0').Replace("\u201d", "\0"));
            }
            catch (WebException)
            {
                new MessageDialog("Няма връзка със сървъра.").ShowAsync();
            }
        }
        
        private ObservableCollection<NameModel> results;

        public IEnumerable<NameModel> Results
        {
            get
            {
                return this.results;
            }
            set
            {
                if (this.results == null)
                {
                    this.results = new ObservableCollection<NameModel>();
                }

                this.results.Clear();

                foreach (var item in value)
                {
                    results.Add(item);                    
                }

                if (this.results.Count <= 0)
                {
                    this.AreResultsEmpty = true;
                }

                this.OnPropertyChanged("Results");
            }
        }
    }
}