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
			new Card { Name = "Attack 1", ImagePath = "res://Resources/CardResources/sword_03c.png", Text = "Deal 1 Damage" },
			new Card { Name = "Attack 2", ImagePath = "res://Resources/CardResources/sword_03c.png", Text = "Deal 2 Damage"  },
			new Card { Name = "Attack 3", ImagePath = "res://Resources/CardResources/sword_03c.png", Text = "Deal 3 Damage"  },
			new Card { Name = "Attack 4", ImagePath = "res://Resources/CardResources/sword_03c.png", Text = "Deal 4 Damage"  },
			new Card { Name = "Attack 5", ImagePath = "res://Resources/CardResources/sword_03c.png", Text = "Deal 5 Damage"  },
			new Card { Name = "Block 1", ImagePath = "res://Resources/CardResources/shield_03c.png", Text = "Block 1 Damage"  },
			new Card { Name = "Block 2", ImagePath = "res://Resources/CardResources/shield_03c.png", Text = "Block 1 Damage"  },
			new Card { Name = "Block 3", ImagePath = "res://Resources/CardResources/shield_03c.png", Text = "Block 1 Damage"  },
			new Card { Name = "Block 4", ImagePath = "res://Resources/CardResources/shield_03c.png", Text = "Block 1 Damage"  },
			new Card { Name = "Block 5", ImagePath = "res://Resources/CardResources/shield_03c.png", Text = "Block 1 Damage"  },
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
