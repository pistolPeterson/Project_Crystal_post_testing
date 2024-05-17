using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackHitbox : MonoBehaviour
{
    public int AttackDamage { get; set; }

    private void Start()
    {
        AttackDamage = 1;//default dmg
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        PlayerHealthPoints potentialPlayerHealth = col.gameObject.GetComponent<PlayerHealthPoints>();
        if (potentialPlayerHealth == null)
            return;

        potentialPlayerHealth.RemoveHealth(AttackDamage);
    }

    public void SetAttackDamage(int attackDamage)
    {
        AttackDamage = attackDamage;
    }
}
