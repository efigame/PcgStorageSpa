using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PcgApi.Models
{
    [DataContract]
    public class SelectedCards
    {
        [DataMember]
        public List<Card> WeaponCards { get; set; }
        [DataMember]
        public List<Card> SpellCards { get; set; }
        [DataMember]
        public List<Card> ArmorCards { get; set; }
        [DataMember]
        public List<Card> ItemCards { get; set; }
        [DataMember]
        public List<Card> AllyCards { get; set; }
        [DataMember]
        public List<Card> BlessingCards { get; set; }

        public SelectedCards(int partyCharacterId)
        {
            WeaponCards = new List<Card>();
            SpellCards = new List<Card>();
            ArmorCards = new List<Card>();
            ItemCards = new List<Card>();
            AllyCards = new List<Card>();
            BlessingCards = new List<Card>();

            var allCards = DataAccess.Dto.CharacterDeck.All(partyCharacterId);
            WeaponCards = SetCardList(allCards.Where(c => c.Card.CardTypeId == 10));
            SpellCards = SetCardList(allCards.Where(c => c.Card.CardTypeId == 11));
            ArmorCards = SetCardList(allCards.Where(c => c.Card.CardTypeId == 13));
            ItemCards = SetCardList(allCards.Where(c => c.Card.CardTypeId == 14));
            AllyCards = SetCardList(allCards.Where(c => c.Card.CardTypeId == 15));
            BlessingCards = SetCardList(allCards.Where(c => c.Card.CardTypeId == 16));
        }
        
        internal void Update(int partyCharacterId)
        {
            var previouslySelectedCards = DataAccess.Dto.CharacterDeck.All(partyCharacterId);
            var previouslySelectedWeaponCards = previouslySelectedCards.Where(c => c.Card.CardTypeId == 10);
            var previouslySelectedSpellCards = previouslySelectedCards.Where(c => c.Card.CardTypeId == 11);
            var previouslySelectedArmorCards = previouslySelectedCards.Where(c => c.Card.CardTypeId == 13);
            var previouslySelectedItemCards = previouslySelectedCards.Where(c => c.Card.CardTypeId == 14);
            var previouslySelectedAllyCards = previouslySelectedCards.Where(c => c.Card.CardTypeId == 15);
            var previouslySelectedBlessingCards = previouslySelectedCards.Where(c => c.Card.CardTypeId == 16);

            UpdateCardList(previouslySelectedWeaponCards, WeaponCards, partyCharacterId);
            UpdateCardList(previouslySelectedSpellCards, SpellCards, partyCharacterId);
            UpdateCardList(previouslySelectedArmorCards, ArmorCards, partyCharacterId);
            UpdateCardList(previouslySelectedItemCards, ItemCards, partyCharacterId);
            UpdateCardList(previouslySelectedAllyCards, AllyCards, partyCharacterId);
            UpdateCardList(previouslySelectedBlessingCards, BlessingCards, partyCharacterId);
        }

        private void UpdateCardList(IEnumerable<DataAccess.Dto.CharacterDeck> previouslySelectedCards, List<Card> selectedCards, int partyCharacterId)
        {
            var newSelectedCards = new List<DataAccess.Dto.CharacterDeck>();

            foreach (var card in previouslySelectedCards)
            {
                newSelectedCards.Add(new DataAccess.Dto.CharacterDeck { CardId = card.CardId, Id = card.Id, PartyCharacterId = card.PartyCharacterId, Count = 0 });
            }

            foreach (var card in selectedCards)
            {
                if (!newSelectedCards.Select(c => c.CardId).Contains(card.Id))
                {
                    newSelectedCards.Add(new DataAccess.Dto.CharacterDeck { CardId = card.Id, Count = 1, PartyCharacterId = partyCharacterId });
                }
                else
                {
                    var newSelectedCard = newSelectedCards.Single(c => c.CardId == card.Id);
                    newSelectedCard.Count++;
                }
            }

            foreach (var card in newSelectedCards)
            {
                if (card.Count == 0)
                {
                    card.Delete();
                }
                else
                {
                    var previouslySelectedCard = previouslySelectedCards.SingleOrDefault(c => c.Id == card.Id);
                    if (previouslySelectedCard == null)
                        card.Persist();
                    else if (previouslySelectedCard.Count != card.Count)
                        card.Update();
                }
            }
        }

        private List<Card> SetCardList(IEnumerable<DataAccess.Dto.CharacterDeck> cards)
        {
            var cardList = new List<Card>();

            foreach (var card in cards)
            {
                for (int i = 1; i <= card.Count; i++)
                {
                    cardList.Add(new Card(card.Card));
                }
            }

            return cardList;
        }

    }
}