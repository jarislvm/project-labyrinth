using Constants;
using Core;
using Godot;
using System;

public partial class MainMenu : Node
{
	public void StartGame()
	{
		GetTree().ChangeBaseScene(Scenes.Battle);
	}

	public void ExitGame()
	{
		GetTree().Quit();
	}
}
