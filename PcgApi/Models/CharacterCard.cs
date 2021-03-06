﻿using System.Runtime.Serialization;

namespace PcgApi.Models
{
    [DataContract]
    public class CharacterCard
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }

        public CharacterCard()
        {
        }

        internal CharacterCard(DataAccess.Dto.CharacterCard card) : this(card, true)
        {
        }
        internal CharacterCard(DataAccess.Dto.CharacterCard card, bool deepObjects)
        {
            Id = card.Id;
            Name = card.Name;

            if (deepObjects)
            {
            }
        }
    }
}