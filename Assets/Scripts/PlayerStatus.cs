using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerStatus : MonoBehaviour {
    public int pride;
    public int money;

    PlayerMovement playerMovement;

    private void Start() {
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            CalculateDamage(0);
        }
    }

    public void CalculateDamage(int damage) {
        if (pride - damage > 0) {
            pride -= damage;
        } else {
            pride = 0;
        }

        playerMovement.Damage();
    }

    public void PlusMoney(int paid, int otherPlayerMoney) {
        if (otherPlayerMoney > 0) {
            money += paid * 10000;
        }
    }

    public void MinusMoney(int pay) {
        if (money - pay > 0) {
            money -= pay * 10000;
        } else {
            money = 0;
        }
    }
}
