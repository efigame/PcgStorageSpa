using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace PcgApi.Models
{
    [DataContract]
    public class AdventurePath
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public List<Adventure> Adventures { get; set; }
        [DataMember]
        public bool Completed { get; set; }

        internal AdventurePath(DataAccess.Dto.Card card, List<DataAccess.Dto.Card> availableCards)
        {
            Id = card.Id;
            Name = card.Name;

            Adventures = new List<Adventure>();
            Adventures.AddRange(availableCards.Where(c => c.CardTypeId == 3).Select(c => new Adventure(c, availableCards)));
        }
    }
}