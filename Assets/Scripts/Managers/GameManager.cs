using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonMonoBehaviour<GameManager> {
    public PlayerStatus player1Status;
    public PlayerStatus player2Status;

    private void Start() {
        SceneLoader.LoadSceneAdditive(Consts.UI);
    }

    private void Update() {
    }
}
