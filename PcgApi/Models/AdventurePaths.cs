﻿using System.Collections.Generic;
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

            AvailableAdventurePaths.AddRange(DataAccess.Dto.AdventurePath.All().Select(c => new AdventurePath(c)));
        }
    }
}