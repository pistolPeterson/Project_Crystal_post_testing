using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayerES : EnemyAIState
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private EnemyRangedBasicAttack basicAttack;
    [SerializeField] private EnemyHealthPoints enemyHealth;
    [SerializeField] private EnemyMovement movement;
    [SerializeField] private float aggroTimeInSeconds = 5f;

    [Header("Debug")]
    [SerializeField] private float stateActiveTime = 0f;
    public override void Start() {
        base.Start();
        enemyHealth.OnHurt.AddListener(OnAttacked);
        playerTransform = GameObject.FindWithTag("Player").transform;
    }
    public override void OnStateEnter() {
        Debug.Log("Enter Player Attack");
        movement.Stop();
    }
    public override void OnStateUpdate() {
        stateActiveTime += Time.deltaTime;

        if (stateActiveTime > aggroTimeInSeconds) {
            enemyStateHandler.ChangeState(enemyStateHandler.MoveTowardCrystalState);
        }

        if (Vector3.Distance(transform.position, playerTransform.position) > enemyStateHandler.AttackCrystalState.AttackRange) {
            enemyStateHandler.ChangeState(enemyStateHandler.MoveTowardPlayerState);
        }
        basicAttack.AttackTarget(playerTransform);
    }
    public override void OnStateExit() {
        stateActiveTime = 0f;
    }
    public void OnAttacked() {
        enemyStateHandler.ChangeState(enemyStateHandler.MoveTowardPlayerState);
    }
}
