using Core.CardEngine;
using Godot;
using System;

public partial class CardTemplate : Control
{
	public Vector2 CardSize { get; } = new(150,240);

	private RichTextLabel _namePlate;
	public Card Card { get; private set; }

	public override void _Ready()
	{
		SetAnchorsPreset(LayoutPreset.TopLeft);
		base._Ready();
	}

	public void SetCard(Card card)
	{
		Card = card;
		_namePlate = (RichTextLabel)FindChild("CardNameLabel", true, false);
		_namePlate.Text = Card.Name;
	}
}
