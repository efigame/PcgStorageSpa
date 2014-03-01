﻿using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Dto
{
    public class Deck
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AdventureId { get; set; }
        public Adventure Adventure { get; set; }

        public static Deck Get(int id)
        {
            Deck deck = null;

            using (var data = new PcgStorageEntities())
            {
                var deckData = data.decks.SingleOrDefault(p => p.Id == id);
                if (deckData != null) deck = new Deck(deckData);
            }

            return deck;
        }
        public static List<Deck> All()
        {
            var decks = new List<Deck>();

            using (var data = new PcgStorageEntities())
            {
                var all = data.decks.ToList();
                decks.AddRange(all.Select(a => new Deck(a)));
            }

            return decks;
        }

        public void Persist()
        {
            using (var data = new PcgStorageEntities())
            {
                var entity = ToEntity();
                data.decks.Add(entity);
                data.SaveChanges();

                Id = entity.Id;
            }
        }
        public void Update()
        {
            using (var data = new PcgStorageEntities())
            {
                var adventure = data.adventures.SingleOrDefault(s => s.Id == Id);
                if (adventure != null)
                {
                    adventure.Name = Name;

                    data.SaveChanges();
                }
            }
        }
        public void Delete()
        {
            using (var data = new PcgStorageEntities())
            {
                var deck = data.decks.SingleOrDefault(s => s.Id == Id);
                if (deck != null)
                {
                    data.decks.Remove(deck);
                    data.SaveChanges();
                }
            }
        }

        public Deck()
        {
        }

        internal Deck(deck deck)
        {
            Id = deck.Id;
            Name = deck.Name;
            AdventureId = deck.AdventureId;
            Adventure = new Adventure(deck.adventure);
        }
        internal deck ToEntity()
        {
            var deck = new deck
            {
                Name = Name,
                AdventureId = AdventureId
            };

            return deck;
        }
    }
}
