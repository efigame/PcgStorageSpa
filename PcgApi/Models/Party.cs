using System.Runtime.Serialization;

namespace PcgApi.Models
{
    [DataContract]
    public class Party
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public Characters Characters { get; set; }

        public Party()
        {
        }
        internal Party(DataAccess.Dto.Party party) : this(party, true)
        {
        }
        internal Party(DataAccess.Dto.Party party, bool deepObjects)
        {
            Id = party.Id;
            Name = party.Name;
            UserId = party.PcgUserId;
            Characters = new Characters();

            if (deepObjects)
            {
                Characters = new Characters(Id);
            }
        }

        internal void Update()
        {
            var party = DataAccess.Dto.Party.Get(Id);
            party.Name = Name;
            party.Update();

            Characters.Update(party.Id);
        }
    }
}