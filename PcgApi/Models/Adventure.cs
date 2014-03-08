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

        internal Adventure(DataAccess.Dto.AdventureDeck adventureDeck)
        {
            Id = adventureDeck.Id;
            Name = adventureDeck.Name;

            Scenarios = new List<Scenario>();
            Scenarios.AddRange(DataAccess.Dto.Scenario.All().Where(s => s.AdventureDeckId == Id).Select(c => new Scenario(c)));
        }
    }
}