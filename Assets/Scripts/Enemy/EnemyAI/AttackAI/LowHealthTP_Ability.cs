using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowHealthTP_Ability : MonoBehaviour
{
    [SerializeField] private EnemyHealthPoints hp;
    [SerializeField] private Transform player;
    [SerializeField] private float precentThreshold = 0.25f;
    [SerializeField] private float posOffset = 1f;
    public bool abilityUsed = false;

    private void Start() {
        hp.OnHurt.AddListener(TeleportAttack);
        player = GameObject.FindWithTag("Player").transform;
    }
    public void TeleportAttack() {
        if (abilityUsed) return;

        var threshHold = hp.maxHP * precentThreshold;
        if (hp.currentHP <= threshHold) {
            Debug.Log("HEEEYAH");
            transform.position = new Vector3(player.position.x+posOffset, player.position.y + posOffset);
            abilityUsed = true;
        }
    }

}
