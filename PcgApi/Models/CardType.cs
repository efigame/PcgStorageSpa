using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PcgApi.Models
{
    [DataContract]
    public class CardType
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int AdventureId { get; set; }

        public CardType()
        {
        }

        internal CardType(DataAccess.Dto.CardType cardType) : this(cardType, true)
        {
        }

        internal CardType(DataAccess.Dto.CardType cardType, bool deepObjects)
        {
            Id = cardType.Id;
            Name = cardType.Name;
            AdventureId = cardType.AdventureId;

            if (deepObjects)
            {
            }
        }
    }
}