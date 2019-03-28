using System.Runtime.Serialization;

namespace TrelloAPI.Models
{
    [DataContract]
    public class BoardList
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "idBoard")]
        public string IdBoard { get; set; }

        [DataMember(Name = "closed")]
        public bool Closed { get; set; }

        [DataMember(Name = "pos")]
        public float Pos { get; set; }

        [DataMember(Name = "subscribed")]
        public bool Subscribed { get; set; }
    }
}
