using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoader {

    public static bool LoadSceneAdditive(string sceneName) {
        for (int i = 0; i < SceneManager.sceneCount; i++) {
            if (SceneManager.GetSceneAt(i).name == sceneName) {
                return false;
            }
        }

        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        return true;
    }
}
