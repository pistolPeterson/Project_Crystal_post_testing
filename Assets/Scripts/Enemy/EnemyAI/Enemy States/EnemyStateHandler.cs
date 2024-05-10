using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateHandler : MonoBehaviour
{
    [field: Header("States")]
    [field: SerializeField] public MoveTowardsPlayerES MoveTowardPlayerState { get; private set; }
    [field: SerializeField] public MoveTowardsCrystalES MoveTowardCrystalState { get; private set; }
    [field: SerializeField] public AttackCrystalES AttackCrystalState { get; private set; }
    [field: SerializeField] public AttackPlayerES AttackPlayerES { get; private set; }

    [Header("Debug")]
    [SerializeField] private EnemyAIState currentState;

    void Start() {
        currentState = MoveTowardCrystalState;
        EnterState();
    }
    public void EnterState() {
        currentState.OnStateEnter();
    }
    void Update() {
        currentState.OnStateUpdate();
    }
    public void ChangeState(EnemyAIState newState) {
        currentState.OnStateExit();
        currentState = newState;
        EnterState();
    } 
}
