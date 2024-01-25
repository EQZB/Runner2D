using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public static ScenesManager Instance { get; private set; }

    
    private void Awake(){

        Instance = this;
    }

    public enum Scene{
        MainMenu,
        Game
    }

    public void LoadScene(Scene scene){

        SceneManager.LoadScene(scene.ToString());
    }

    public void LoadNewGame(){

        SceneManager.LoadScene(Scene.Game.ToString());
    }

    public void LoadMainMenu(){

        SceneManager.LoadScene(Scene.MainMenu.ToString());
    }

}
