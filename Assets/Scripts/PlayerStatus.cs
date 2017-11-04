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
            calculateDamage(0);
        }
    }

    public void calculateDamage(int damage) {
        if (pride - damage > 0) {
            pride -= damage;
        } else {
            pride = 0;
        }

        playerMovement.Damage();
    }
}
