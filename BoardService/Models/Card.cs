using System.Runtime.Serialization;


namespace TrelloAPI.Models
{
    [DataContract]
    public class Card
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "badges")]
        public Badges Badges { get; set; }

        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "desc")]
        public string Description { get; set; }

        [DataMember(Name = "descData")]
        public string DescData { get; set; }

        [DataMember(Name = "pos")]
        public float Pos { get; set; }

        [DataMember(Name = "closed")]
        public bool Closed { get; set; }

        [DataMember(Name = "dateLastActivity")]
        public System.DateTime DateLastActivity { get; set; }

        [DataMember(Name = "due")]
        public System.DateTime Due { get; set; }

        [DataMember(Name = "dueComplete")]
        public bool DueComplete { get; set; }

        [DataMember(Name = "checkItemStates")]
        public object [] CheckItemStates { get; set; }

        [DataMember(Name = "idAttachmentCover")]
        public string IdAttachmentCover { get; set; }

        [DataMember(Name = "idBoard")]
        public string IdBoard { get; set; }

        [DataMember(Name = "idChecklists")]
        public string [] IdChecklists { get; set; }

        [DataMember(Name = "idLabels")]
        public string[] IdLabels { get; set; }

        [DataMember(Name = "idList")]
        public string IdList { get; set; }

        [DataMember(Name = "idMembers")]
        public string[] IdMembers { get; set; }

        [DataMember(Name = "idMembersVoted")]
        public string[] IdMembersVoted { get; set; }

        [DataMember(Name = "idShort")]
        public int IdShort { get; set; }

        [DataMember(Name = "labels")]
        public Label [] Labels { get; set; }

        [DataMember(Name = "manualCoverAttachment")]
        public bool ManualCoverAttachment { get; set; }

        [DataMember(Name = "shortLink")]
        public string ShortLink { get; set; }

        [DataMember(Name = "shortUrl")]
        public string ShortUrl { get; set; }

        [DataMember(Name = "subscribed")]
        public bool Subscribed { get; set; }

        [DataMember(Name = "url")]
        public string Url { get; set; }

        [DataMember(Name = "address")]
        public string Address { get; set; }

        [DataMember(Name = "locationName")]
        public string LocationName { get; set; }

        [DataMember(Name = "coordinates")]
        public object Coordinates { get; set; }
    }

    [DataContract]
    public class Badges
    {
        [DataMember(Name = "votes")]
        public int Votes { get; set; }

        [DataMember(Name = "viewingMemberVoted")]
        public bool ViewingMemberVoted { get; set; }

        [DataMember(Name = "subscribed")]
        public bool Subscribed { get; set; }

        [DataMember(Name = "dueComplete")]
        public bool DueComplete { get; set; }

        [DataMember(Name = "description")]
        public bool Description { get; set; }

        [DataMember(Name = "fogbugz")]
        public string Fogbugz { get; set; }

        [DataMember(Name = "checkItems")]
        public int CheckItems { get; set; }

        [DataMember(Name = "checkItemsChecked")]
        public int CheckItemsChecked { get; set; }

        [DataMember(Name = "comments")]
        public int Comments { get; set; }

        [DataMember(Name = "attachments")]
        public int Attachments { get; set; }

        [DataMember(Name = "due")]
        public object Due { get; set; }
    }
}
