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
        public string PowersListText { get; set; }
        [DataMember]
        public List<KeyValuePair<string, bool>> PowersList { get; set; }
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
        [DataMember]
        public int PartyCharacterId { get; set; }

        public Power()
        {
        }

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
            PartyCharacterId = partyCharacterId;
            PowersList = new List<KeyValuePair<string, bool>>();

            if (deepObjects)
            {
                var selectedPower = DataAccess.Dto.CharacterPower.All(partyCharacterId).SingleOrDefault(c => c.PowerId == Id);
                if (selectedPower != null)
                    SelectedPowers = selectedPower.SelectedPowers;
                else
                    SelectedPowers = 0;

                string[] powerlist = power.Text.Split(new string[] { "{format:check}" }, StringSplitOptions.None);
                if (powerlist.Count() > 0)
                {
                    PowersListText = powerlist[0];

                    for (int i = 1; i < powerlist.Count(); i++)
                    {
                        if ((i & SelectedPowers) == i)
                            PowersList.Add(new KeyValuePair<string, bool>(powerlist[i], true));
                        else
                            PowersList.Add(new KeyValuePair<string, bool>(powerlist[i], false));
                    }
                }
            }
        }

        internal void SetSelectedPower()
        {
            var selectedValue = 0;
            var bitStep = 1;

            for (var i = 0; i < PowersList.Count(); i++)
            {
                if (PowersList[i].Value)
                    selectedValue += bitStep;

                bitStep += bitStep;
            }

            var characterPower = DataAccess.Dto.CharacterPower.All(PartyCharacterId).SingleOrDefault(c => c.PowerId == Id);
            if (characterPower != null)
            {
                characterPower.SelectedPowers = selectedValue;
                characterPower.Update();
            }
            else
            {
                characterPower = new DataAccess.Dto.CharacterPower
                {
                    PartyCharacterId = PartyCharacterId,
                    PowerId = Id,
                    SelectedPowers = selectedValue
                };

                characterPower.Persist();
            }
        }
    }
}