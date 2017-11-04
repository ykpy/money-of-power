using UnityEngine;

public class PlayerStatus : MonoBehaviour {
    public int pride;
    public int money;

    public void calculateDamage(int damage) {
        if (pride - damage > 0) {
            pride -= damage;
        } else {
            pride = 0;
        }
    }
}
