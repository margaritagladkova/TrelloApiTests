using System.Runtime.Serialization;

namespace TrelloAPI.Models
{
    [DataContract]
    public class Label
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "idBoard")]
        public string IdBoard { get; set; }

        [DataMember(Name = "color")]
        public string Color { get; set; }
    }
}
