using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerInput {

    public enum PlayerID {
        Player1,
        Player2,
        Any
    };
    public static PlayerID[] playerIds = { PlayerID.Player1, PlayerID.Player2 };

    public static bool GetButtonDown(string inputName, PlayerID playerId = PlayerID.Any) {
        if (playerId == PlayerID.Any) {
            foreach (var id in playerIds) {
                if (Input.GetButtonDown(inputName + '_' + id.ToString())) {
                    return true;
                }
            }
            return false;
        }
        return Input.GetButtonDown(inputName + '_' + playerId.ToString());
    }

    public static float GetAxis(string inputName, PlayerID playerId) {
        return Input.GetAxis(inputName + '_' + playerId.ToString());
    }
}
