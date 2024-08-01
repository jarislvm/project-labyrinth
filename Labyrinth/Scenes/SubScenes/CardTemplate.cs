using Core.CardEngine;
using Godot;
using System;

public partial class CardTemplate : Area2D
{
	public Vector2 CardSize { get; } = new(150,240);

	private RichTextLabel _namePlate;
	private TextureRect _image;
	private RichTextLabel _textPlate;
	public Card Card { get; private set; }

	public override void _Ready()
	{
		//SetAnchorsPreset(LayoutPreset.TopLeft);
		base._Ready();
	}

	public void SetCard(Card card)
	{

		_namePlate = (RichTextLabel)FindChild("CardNameLabel", true, false);
		_image = (TextureRect)FindChild("CardImage", true, false);
		_textPlate = (RichTextLabel)FindChild("CardText", true, false);

		Card = card;
		_namePlate.Text = Card.Name;
		var image = Image.LoadFromFile(card.ImagePath);
		_image.Texture = ImageTexture.CreateFromImage(image);
		_textPlate.Text = Card.Text;
	}
}
