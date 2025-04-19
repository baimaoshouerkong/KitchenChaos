using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader
{
    public enum Scene
    {
        MainMenuScene,
        GameScene,
        LoadingScene,
    }
    public enum GameType
    {
        None,
        New,
        Load,
    }
    public static Scene targetScene;
    public static GameType gameType;
    public static void Load(Scene targetScene, GameType gameType=GameType.None)
    {
        Loader.targetScene = targetScene;
        Loader.gameType = gameType;
        SceneManager.LoadScene(Scene.LoadingScene.ToString());

    }
    public static void LoaderCallback()
    {
        SceneManager.LoadScene(targetScene.ToString());
        if (gameType == GameType.Load)
        {
            SaveManager.Instance.LoadGame();
        }
    }
}
