using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace PcgApi.Models
{
    [DataContract]
    public class AdventurePaths
    {
        [DataMember]
        public List<AdventurePath> AvailableAdventurePaths { get; set; }

        internal AdventurePaths()
        {
            AvailableAdventurePaths = new List<AdventurePath>();

            var availableCards = DataAccess.Dto.Card.All();
            AvailableAdventurePaths.AddRange(availableCards.Where(c => c.CardTypeId == 2).Select(c => new AdventurePath(c, availableCards)));
        }
    }
}