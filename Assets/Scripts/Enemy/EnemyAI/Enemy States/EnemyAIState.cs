using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAIState : MonoBehaviour
{
    protected EnemyStateHandler enemyStateHandler;
    public virtual void Start()
    {
        enemyStateHandler = GetComponentInParent<EnemyStateHandler>();
    }
    public abstract void OnStateEnter();
    public abstract void OnStateUpdate();
    public abstract void OnStateExit();
}
