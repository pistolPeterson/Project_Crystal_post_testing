using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsPlayerES : EnemyAIState 
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private EnemyMovement movement;
    [SerializeField] private float chaseTimeInSeconds = 3f;

    [Header("Debug")]
    [SerializeField] private float stateActiveTime = 0f;
    public override void Start() {
        playerTransform = GameObject.FindWithTag("Player").transform;
        base.Start();
    }
    public override void OnStateEnter() {
        movement.SetTarget(playerTransform);
        movement.Move();
    }
    public override void OnStateUpdate() {
        stateActiveTime += Time.deltaTime;

        if (stateActiveTime > chaseTimeInSeconds) {
            enemyStateHandler.ChangeState(enemyStateHandler.MoveTowardCrystalState);
        }

        if (Vector3.Distance(transform.position, playerTransform.position) <= enemyStateHandler.AttackCrystalState.AttackRange) {
            enemyStateHandler.ChangeState(enemyStateHandler.AttackPlayerES);
        }
    }
    public override void OnStateExit() {
        stateActiveTime = 0f;
    }
}
