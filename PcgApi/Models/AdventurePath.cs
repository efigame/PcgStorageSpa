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

        internal AdventurePath(DataAccess.Dto.AdventurePath adventurePath)
        {
            Id = adventurePath.Id;
            Name = adventurePath.Name;

            Adventures = new List<Adventure>();
            Adventures.AddRange(DataAccess.Dto.AdventureDeck.All().Where(s => s.AdventurePathId == Id).Select(c => new Adventure(c)));
        }
    }
}