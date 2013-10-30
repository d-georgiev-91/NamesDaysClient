namespace NamesDaysClient.Model
{
    using System;
    using System.Runtime.Serialization;

    [DataContract]
    public class NameModel
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "date")]
        public DateTime Date { get; set; }

        [DataMember(Name = "nameDayTitle")]
        public string NameDayTitle { get; set; }
    }
}