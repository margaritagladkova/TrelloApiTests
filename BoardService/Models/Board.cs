using System.Runtime.Serialization;

namespace TrelloAPI.Models
{
    [DataContract]
    public class Board
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "desc")]
        public string Description { get; set; }

        [DataMember(Name = "descData")]
        public string DescData { get; set; }

        [DataMember(Name = "idOrganization")]
        public string IdOrganization { get; set; }

        [DataMember(Name = "closed")]
        public bool Closed { get; set; }

        [DataMember(Name = "pinned")]
        public bool? Pinned { get; set; }

        [DataMember(Name = "starred")]
        public bool Starred { get; set; }

        [DataMember(Name = "url")]
        public string Url { get; set; }

        [DataMember(Name = "shortUrl")]
        public string ShortUrl { get; set; }

        [DataMember(Name = "prefs")]
        public object Prefs { get; set; }

        [DataMember(Name = "limits")]
        public object Limits { get; set; }

        [DataMember(Name = "labelNames")]
        public object LabelNames { get; set; }

        [DataMember(Name = "memberships")]
        public object Memberships { get; set; }
    }
}
