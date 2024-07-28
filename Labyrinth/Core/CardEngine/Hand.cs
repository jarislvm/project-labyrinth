using System.Collections.Generic;
using System.Linq;

namespace Core.CardEngine
{
	public class Hand
	{
		public int MaxHandSize { get; set; } = 10;
		public List<Card> Cards { get; } = new();
		public bool CanAddCards => Cards.Count() <= MaxHandSize;

		public bool AddCardToHand(Card card)
		{
			if(CanAddCards)
			{
				Cards.Add(card);
				return true;
			}
			return false;
		}
	}
}
