using System.Collections.Generic;
using System.Linq;
using Constants;
using Core;
using Core.CardEngine;
using Godot;

public partial class BattleScene : Node2D
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
		currentCardName = (RichTextLabel)FindChild("CardNameLabel", false, true);
		base._Ready();
	}

	private RichTextLabel currentCardName;

	private Deck DrawPile = new Deck();
	private Deck DiscardPile = new Deck();
	private Hand Hand = new Hand();

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
			Hand.Cards.Append(card);
			currentCardName.Text = card.Name;
			DiscardPile.AddCardAtIndex(card, 0);
		}
	}
}
