using System.Collections.Generic;
using System.Linq;
using Constants;
using Core;
using Core.CardEngine;
using Godot;

/// <summary>
/// This class should handle all UI work for the battle scene, logic for cards, enemies, etc should be abstracted into CoreBattleContext.cs
/// </summary>
public partial class BattleScene : Node
{
	public override void _Ready()
	{
		DrawPile.AddCardsAndShuffle(new List<Card>{
			new Card { Name = "Card1" },
			new Card { Name = "Card2" },
			new Card { Name = "Card3" },
			new Card { Name = "Card4" },
			new Card { Name = "Card5" },
			new Card { Name = "Card6" },
			new Card { Name = "Card7" },
			new Card { Name = "Card8" },
			new Card { Name = "Card9" },
			new Card { Name = "Card10" },
		});
		currentCardName = (RichTextLabel)FindChild("CardNameLabel", true, true);
		_hand = (Hand)FindChild("Hand");
		base._Ready();
	}

	private RichTextLabel currentCardName;
	private Hand _hand;

	private Deck DrawPile = new Deck();
	private Deck DiscardPile = new Deck();

	public void ReturnToMain()
	{
		GetTree().ChangeBaseScene(Scenes.MainMenu);
	}

	public void DrawCard()
	{
		var card = DrawPile.Draw();
		if(card == null)
		{
			currentCardName.Text = "No cards left in deck. Shuffling...";
			DrawPile.AddCardsAndShuffle(DiscardPile.RemoveAll());
		}
		else
		{
			_hand.AddCardToHand(card);
			currentCardName.Text = card.Name;
			DiscardPile.AddCardAtIndex(card, 0);
		}
	}
}
