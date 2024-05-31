using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsCrystalES : EnemyAIState 
{
    [SerializeField] private EnemyRangedBasicAttack basicAttack;
    [SerializeField] private EnemyHealthPoints enemyHealth;
    [SerializeField] private EnemyMovement movement;
    [SerializeField] private Crystal currentCrystal;
    
    public override void Start() {
        base.Start();
        enemyHealth.OnHurt.AddListener(OnAttacked);

        if(CrystalManager.Instance.GetCurrentCrystal() != null)
            currentCrystal = CrystalManager.Instance.GetCurrentCrystal();
      
    }
    public override void OnStateEnter() {
        movement.SetTarget(currentCrystal.transform);
        movement.Move();
    }
    public override void OnStateUpdate() {
        if (Vector3.Distance(transform.position, currentCrystal.transform.position) <= enemyStateHandler.AttackCrystalState.AttackRange) {
            enemyStateHandler.ChangeState(enemyStateHandler.AttackCrystalState);
        }
    }
    public void OnAttacked() {
        enemyStateHandler.ChangeState(enemyStateHandler.MoveTowardPlayerState);
    }
    public override void OnStateExit() {
        Debug.Log("Exiting Move To Crystal");
    }
}
