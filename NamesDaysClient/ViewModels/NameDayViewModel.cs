namespace NamesDaysClient.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq.Expressions;
    using NamesDaysClient.Common;
    using NamesDaysClient.Model;

    public class NameDayViewModel : BindableBase
    {
        public string Title { get; set; }

        public DateTime Date { get; set; }

        private ObservableCollection<NameModel> names;

        public IEnumerable<NameModel> Names
        {
            get
            {
                return names;
            }
            set
            {
                if (names == null)
                {
                    names = new ObservableCollection<NameModel>();
                }

                names.Clear();

                foreach (var name in value)
                {
                    names.Add(name);
                }

                this.OnPropertyChanged("Names");
            }
        }

        public static Expression<Func<NameDayModel, NameDayViewModel>> FromNameDayModel
        {
            get
            {
                return nameDay => new NameDayViewModel()
                {
                    Title = nameDay.Title,
                    Names = nameDay.Names,
                    Date = nameDay.Date
                };
            }
        }
    }
}