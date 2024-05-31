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
        currentCrystal = CrystalManager.Instance.GetCurrentCrystal();
    }
    public override void OnStateEnter() {
        movement.Stop();
    }
    public override void OnStateUpdate() {
        basicAttack.AttackTarget(currentCrystal.transform);
    }
    public override void OnStateExit() {

    }
    public void OnAttacked() {
        enemyStateHandler.ChangeState(enemyStateHandler.MoveTowardPlayerState);
    }
}
