namespace NamesDaysClient.Model
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public class NameDayModel
    {
        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "date")]
        public DateTime Date { get; set; }

        [DataMember(Name = "names")]
        public IEnumerable<NameModel> Names { get; set; }
    }
}