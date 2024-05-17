using com.cyborgAssets.inspectorButtonPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeBasicAttack : MonoBehaviour
{
    [SerializeField] private int AttackDamage = 25;
    [SerializeField] private EnemyAnimation enemyAnim;
    [SerializeField] private EnemyAttackHitbox enemyAttackHitbox;


    private void Start()
    {
        enemyAttackHitbox.SetAttackDamage(AttackDamage);
    }
    [ProButton]
    public void Attack()
    {
        enemyAnim.PlayAttackAnim();
      
    }
}
