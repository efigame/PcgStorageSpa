using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

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
        [DataMember]
        public List<CharacterDeck> DeckWeapons { get; set; }
        [DataMember]
        public List<CharacterDeck> DeckSpells { get; set; }
        [DataMember]
        public List<CharacterDeck> DeckArmors { get; set; }
        [DataMember]
        public List<CharacterDeck> DeckItems { get; set; }
        [DataMember]
        public List<CharacterDeck> DeckAllies { get; set; }
        [DataMember]
        public List<CharacterDeck> DeckBlessings { get; set; }

        public SelectedCards(int partyCharacterId)
        {
            WeaponCards = new List<Card>();
            SpellCards = new List<Card>();
            ArmorCards = new List<Card>();
            ItemCards = new List<Card>();
            AllyCards = new List<Card>();
            BlessingCards = new List<Card>();

            var allCards = DataAccess.Dto.CharacterDeck.All(partyCharacterId);

            //DeckWeapons = allCards.Where(c => c.Card.CardTypeId == 10).Select(c => new CharacterDeck(c)).ToList();
            //DeckSpells = allCards.Where(c => c.Card.CardTypeId == 11).Select(c => new CharacterDeck(c)).ToList();
            //DeckArmors = allCards.Where(c => c.Card.CardTypeId == 13).Select(c => new CharacterDeck(c)).ToList();
            //DeckItems = allCards.Where(c => c.Card.CardTypeId == 14).Select(c => new CharacterDeck(c)).ToList();
            //DeckAllies = allCards.Where(c => c.Card.CardTypeId == 15).Select(c => new CharacterDeck(c)).ToList();
            //DeckBlessings = allCards.Where(c => c.Card.CardTypeId == 16).Select(c => new CharacterDeck(c)).ToList();

            //WeaponCards = SetCardList(allCards.Where(c => c.Card.CardTypeId == 10));
            //SpellCards = SetCardList(allCards.Where(c => c.Card.CardTypeId == 11));
            //ArmorCards = SetCardList(allCards.Where(c => c.Card.CardTypeId == 13));
            //ItemCards = SetCardList(allCards.Where(c => c.Card.CardTypeId == 14));
            //AllyCards = SetCardList(allCards.Where(c => c.Card.CardTypeId == 15));
            //BlessingCards = SetCardList(allCards.Where(c => c.Card.CardTypeId == 16));
        }
        
        internal void Update(int partyCharacterId)
        {
            var previouslySelectedCards = DataAccess.Dto.CharacterDeck.All(partyCharacterId);
            //var previouslySelectedWeaponCards = previouslySelectedCards.Where(c => c.Card.CardTypeId == 10).ToList();
            //var previouslySelectedSpellCards = previouslySelectedCards.Where(c => c.Card.CardTypeId == 11).ToList();
            //var previouslySelectedArmorCards = previouslySelectedCards.Where(c => c.Card.CardTypeId == 13).ToList();
            //var previouslySelectedItemCards = previouslySelectedCards.Where(c => c.Card.CardTypeId == 14).ToList();
            //var previouslySelectedAllyCards = previouslySelectedCards.Where(c => c.Card.CardTypeId == 15).ToList();
            //var previouslySelectedBlessingCards = previouslySelectedCards.Where(c => c.Card.CardTypeId == 16).ToList();

            //UpdateCardList(previouslySelectedWeaponCards, WeaponCards, partyCharacterId);
            //UpdateCardList(previouslySelectedSpellCards, SpellCards, partyCharacterId);
            //UpdateCardList(previouslySelectedArmorCards, ArmorCards, partyCharacterId);
            //UpdateCardList(previouslySelectedItemCards, ItemCards, partyCharacterId);
            //UpdateCardList(previouslySelectedAllyCards, AllyCards, partyCharacterId);
            //UpdateCardList(previouslySelectedBlessingCards, BlessingCards, partyCharacterId);
        }

        private void UpdateCardList(IList<DataAccess.Dto.CharacterDeck> previouslySelectedCards, IEnumerable<Card> selectedCards, int partyCharacterId)
        {
            var newSelectedCards = previouslySelectedCards.Select(card => new DataAccess.Dto.CharacterDeck {CardId = card.CardId, Id = card.Id, CharacterId = card.CharacterId, Count = 0}).ToList();

            foreach (var card in selectedCards)
            {
                if (!newSelectedCards.Select(c => c.CardId).Contains(card.Id))
                {
                    newSelectedCards.Add(new DataAccess.Dto.CharacterDeck { CardId = card.Id, Count = 1, CharacterId = partyCharacterId });
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
                    //cardList.Add(new Card(card.Card));
                }
            }

            return cardList;
        }

    }
}