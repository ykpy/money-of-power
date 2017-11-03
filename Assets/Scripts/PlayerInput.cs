using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerInput {

    public enum PlayerID {
        Player1,
        Player2
    };

    public static bool GetButtonDown(string inputName, PlayerID playerId) {
        return Input.GetButtonDown(inputName + '_' + playerId.ToString());
    }

    public static float GetAxis(string inputName, PlayerID playerId) {
        return Input.GetAxis(inputName + '_' + playerId.ToString());
    }
}
