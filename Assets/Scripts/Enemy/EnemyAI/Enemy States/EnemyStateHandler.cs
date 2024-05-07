using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateHandler : MonoBehaviour
{
    private EnemyAIState currentState;

    void Start() {
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
