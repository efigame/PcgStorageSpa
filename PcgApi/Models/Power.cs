using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PcgApi.Models
{
    [DataContract]
    public class Power
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Text { get; set; }
        [DataMember]
        public int Number { get; set; }
        [DataMember]
        public int? Adjustment { get; set; }
        [DataMember]
        public int CharacterCardId { get; set; }
        [DataMember]
        public int? Dice { get; set; }
        [DataMember]
        public int? SelectedPowers { get; set; }

        internal Power(DataAccess.Dto.Power power, int partyCharacterId) : this(power, partyCharacterId, true)
        {
        }
        internal Power(DataAccess.Dto.Power power, int partyCharacterId, bool deepObjects)
        {
            Id = power.Id;
            Text = power.Text;
            Number = power.Number;
            Adjustment = power.Adjustment;
            CharacterCardId = power.CharacterCardId;
            Dice = power.Dice;

            if (deepObjects)
            {
                var selectedPower = DataAccess.Dto.CharacterPower.All(partyCharacterId).SingleOrDefault(c => c.PowerId == Id);
                if (selectedPower != null)
                    SelectedPowers = selectedPower.SelectedPowers;
                else
                    SelectedPowers = 0;
            }
        }
    }
}