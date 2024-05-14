using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCrystalES : EnemyAIState 
{    
    [field: SerializeField] public float AttackRange { get; private set; }
    [SerializeField] private EnemyRangedBasicAttack basicAttack;
    [SerializeField] private Crystal currentCrystal;
    [SerializeField] private EnemyMovement movement;
    [SerializeField] private EnemyHealthPoints enemyHealth;

    public override void Start() {
        base.Start();
        enemyHealth.OnHurt.AddListener(OnAttacked);
    }
    public override void OnStateEnter() {
        Debug.Log("Enter Attack Crystal");
        movement.Stop();
    }
    public override void OnStateUpdate() {
        Debug.Log("Enemy Attaccking");
        basicAttack.AttackTarget(currentCrystal.transform);
    }
    public override void OnStateExit() {

    }
    public void OnAttacked() {
        enemyStateHandler.ChangeState(enemyStateHandler.MoveTowardPlayerState);
    }
}
