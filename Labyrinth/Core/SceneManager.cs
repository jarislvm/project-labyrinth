using Godot;

namespace Core
{
    public static class SceneManager
    {
        public static Error ChangeBaseScene(this SceneTree sceneTree, string scene)
        {
            var packedScene = GD.Load<PackedScene>(scene);
		    return sceneTree.ChangeSceneToPacked(packedScene);
        }
    }
}