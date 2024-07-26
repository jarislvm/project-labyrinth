using System;
using System.Collections.Generic;
using System.Linq;
using Godot;

namespace Core.CardEngine
{
    public class Deck : ICardPile
    {
        public List<Card> Cards { get; } = new();

        public Card Draw()
        {
            if(Cards.Any())
            {
                var retval = Cards.First();
                Cards.Remove(retval);
                return retval;
            }
            return null;
        }

        public void AddCardsAndShuffle(IEnumerable<Card> cards)
        {
            Cards.AddRange(cards);
            Shuffle();
        }

        public void AddCardAtIndex(Card card, int index)
        {
            Cards.Insert(index, card);
        }

        public void Shuffle()
        {
            var rng = new RandomNumberGenerator();
            var shuffledList = new List<KeyValuePair<float,Card>>();
            foreach(var c in Cards)
            {
                shuffledList.Add(new KeyValuePair<float, Card>(rng.Randf(),c));
            }
            Cards.RemoveAll(_ => true);
            Cards.AddRange(shuffledList.OrderBy(_ => _.Key).Select(_ => _.Value).ToList());
        }

        public IEnumerable<Card> RemoveAll()
        {
            var cardsRemoved = Cards.ToList();
            Cards.RemoveAll(_ => true);
            return cardsRemoved;
        }
    }

    public interface ICardPile
    {
    }
}