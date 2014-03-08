using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace PcgApi.Models
{
    [DataContract]
    public class Adventure
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public bool Completed { get; set; }
        [DataMember]
        public List<Scenario> Scenarios { get; set; }

        internal Adventure(DataAccess.Dto.Card card, IEnumerable<DataAccess.Dto.Card> availableCards)
        {
            Id = card.Id;
            Name = card.Name;

            Scenarios = new List<Scenario>();
            Scenarios.AddRange(availableCards.Where(c => c.CardTypeId == 4).Select(c => new Scenario(c)));
        }
    }
}