namespace NamesDaysClient.Helpers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using NamesDaysClient.Model;
    using NamesDaysClient.ViewModel;

    public class DataPersister
    {
        private const string BaseUrl = "http://imennidni.apphb.com/api/";

        public async static Task<IEnumerable<NameDayModel>> GetTodaysNameDay()
        {
            var nameModel = await HttpRequester.Get<IEnumerable<NameDayModel>>(BaseUrl + "namesdays/today");

            return nameModel;
        }

        public async static Task<IEnumerable<NameDayViewModel>> GetNamesDaysByMonth(int month)
        {
            var nameDay = await HttpRequester.Get<IEnumerable<NameDayModel>>(BaseUrl +
                                                                             string.Format("namesdays?month={0}", month));
            return nameDay.AsQueryable().Select(NameDayViewModel.FromNameDayModel);
        }

        public async static Task<IEnumerable<NameDayModel>> GetNamesDaysByMonthAnDay(int month, int day)
        {
            var nameModel = await HttpRequester.Get<IEnumerable<NameDayModel>>(BaseUrl +
                                                                               string.Format("namesdays?month={0}&day={1}", month, day));

            return nameModel;
        }

        public async static Task<IEnumerable<NameDayModel>> GetAll()
        {
            var nameModel = await HttpRequester.Get<IEnumerable<NameDayModel>>(BaseUrl + "namesdays/today");

            return nameModel;
        }

        public async static Task<IEnumerable<NameModel>> GetName(string name)
        {
            var nameModel = await HttpRequester.Get <IEnumerable<NameModel>>(BaseUrl + string.Format("names?name={0}", name));

            return nameModel;
        }
    }
}