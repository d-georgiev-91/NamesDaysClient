namespace NamesDaysClient.ViewModel
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using NamesDaysClient.Common;
    using NamesDaysClient.Model;

    public class NameDayNamesViewModel : BindableBase
    {
        private ObservableCollection<NameModel> names;

        public IEnumerable<NameModel> Names
        {
            get
            {
                return this.names;
            }
            set
            {
                if (this.names == null)
                {
                    this.names = new ObservableCollection<NameModel>();
                }

                this.names.Clear();

                foreach (var name in value)
                {
                    this.names.Add(name);
                }

                this.OnPropertyChanged("Names");
            }
        }
    }
}