namespace NamesDaysClient.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Net;
    using NamesDaysClient.Common;
    using NamesDaysClient.Helpers;
    using Windows.UI.Popups;

    public class HomePageViewModel : BindableBase
    {
        private ObservableCollection<NameDayViewModel> namesDaysViewModels;

        public HomePageViewModel()
        {
            this.CurrentMonth = DateTime.Now.Month;
            LoadNamesDaysAsync();
        }

        private async void LoadNamesDaysAsync()
        {
            try
            {
                this.NamesDaysModels = await DataPersister.GetNamesDaysByMonth(this.CurrentMonth);
            }
            catch (WebException)
            {
                new MessageDialog("Няма връзка със сървъра.").ShowAsync();
            }
        }

        private int currentMonth;

        public int CurrentMonth
        {
            get
            {
                return currentMonth;
            }
            set
            {
                currentMonth = value;
                this.LoadNamesDaysAsync();
                this.OnPropertyChanged("CurrentMonth");
            }
        }

        public IEnumerable<NameDayViewModel> NamesDaysModels
        {
            get
            {
                return this.namesDaysViewModels;
            }
            set
            {
                if (this.namesDaysViewModels == null)
                {
                    this.namesDaysViewModels = new ObservableCollection<NameDayViewModel>();
                }

                this.namesDaysViewModels.Clear();

                foreach (var item in value)
                {
                    this.namesDaysViewModels.Add(item);
                }

                this.OnPropertyChanged("NamesDaysModels");
            }
        }
    }
}