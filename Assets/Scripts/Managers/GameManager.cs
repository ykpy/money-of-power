using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonMonoBehaviour<GameManager> {
    public PlayerMovement player;

    private void Start() {
        SceneManager.LoadScene(Consts.UI, LoadSceneMode.Additive);
    }

    private void Update() {
    }
}
