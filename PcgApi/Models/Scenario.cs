using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace PcgApi.Models
{
    [DataContract]
    public class Scenario
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public bool Completed { get; set; }

        internal Scenario(DataAccess.Dto.Card card)
        {
            Id = card.Id;
            Name = card.Name;
        }
    }
}