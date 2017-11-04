using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : SingletonMonoBehaviour<TitleManager> {

    private void Update() {
        if (PlayerInput.GetButtonDown("Fire1")) {
            SceneManager.LoadScene(Consts.MAIN);
        }
    }
}
