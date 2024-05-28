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
        if (!CurrentStateNullCheck()) 
            return;


        currentState = MoveTowardCrystalState;
        EnterState();
    }
    public void EnterState() {
        if (!CurrentStateNullCheck())
            return;

        currentState.OnStateEnter();
    }
    void Update() {
        if (!CurrentStateNullCheck())
            return;

        currentState.OnStateUpdate();
    }
    public void ChangeState(EnemyAIState newState) {
        if (!CurrentStateNullCheck())
            return;

        currentState.OnStateExit();
        currentState = newState;
        EnterState();
    }

    public bool CurrentStateNullCheck() => currentState != null; //have to add this because state handler isnt generic now raeus :)
    // yes perfect
}
