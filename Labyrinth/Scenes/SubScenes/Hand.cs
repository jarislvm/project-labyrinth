using Constants;
using Core.CardEngine;
using Godot;
using System;
using System.Collections.Generic;

public partial class Hand : Area2D
{
	public override void _Ready()
	{
		_cardContainer = GetChild<CollisionShape2D>(0);
		base._Ready();
	}

	public List<CardDisplayInfo> CardsInHand { get; } = new();
	public int Count => CardsInHand.Count;
	private CollisionShape2D _cardContainer;

	public void AddCardToHand(Card card)
	{
		var cardInfo = new CardDisplayInfo{
			Card = card,
			DisplayIndex = Count
		};
		var cardScene = GD.Load<PackedScene>(Scenes.Card).Instantiate() as CardTemplate;
		cardScene.SetCard(card);
		cardScene.Owner = _cardContainer;
		cardScene.Position = new Vector2(_cardContainer.Position.X+(cardInfo.DisplayIndex*(cardScene.CardSize.X+10)),_cardContainer.Position.Y);
		cardInfo.CardTemplate = cardScene;
		CardsInHand.Add(cardInfo);
		_cardContainer.AddChild(cardScene);
	}
}

public class CardDisplayInfo
{
	public Card Card { get; set; }
	public int DisplayIndex { get; set; }
	public CardTemplate CardTemplate { get; set; }
}
