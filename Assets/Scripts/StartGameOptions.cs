using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StartGameOptions : MonoBehaviour
{
    [SerializeField] Button _startGame;
    
    public void Start(){
        _startGame.onClick.AddListener(StartNewGame);
    }

    private void StartNewGame(){

        ScenesManager.Instance.LoadNewGame();
    }
}
