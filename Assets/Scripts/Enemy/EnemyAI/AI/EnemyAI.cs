using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : Movement
{
    [SerializeField] private Transform player;
    [SerializeField] private float aggroTime = 2f;
    [SerializeField] private float avoidTime = 1f;
    [SerializeField] private EnemyAIType enemyAIType;
    [SerializeField] private EnemyAttackType enemyAttackType;
    [SerializeField] private EnemyState enemyCurrentState;
    [SerializeField] private bool inDanger;
    [SerializeField] private float attackRange;
    [SerializeField] private Transform crystalObject;
    private Transform currTarget;
    private float currentAggroTimer;
    private bool isAggroTimerActive = false;
    private float currentAvoidTimer;
    private bool isAvoidTimerActive = false;

    private void Start()
    {

        SetInitialTarget();
    }

    public void SetInitialTarget()
    {
        if (!crystalObject)
        {
            enemyCurrentState = EnemyState.MOVETOWARDSPLAYER;
            return;
        }
        currTarget = crystalObject;

        enemyCurrentState = EnemyState.MOVETOWARDSCRYSTAL;
    }

    private void Update()
    { 
        if (isAvoidTimerActive)
        {
            currentAvoidTimer -= Time.deltaTime;
            if (currentAvoidTimer <= 0)
            {
                enemyCurrentState = EnemyState.MOVETOWARDSCRYSTAL;
                isAvoidTimerActive = false;
            }
        }
        if (isAggroTimerActive)
        {
            currentAggroTimer -= Time.deltaTime;
            if (currentAggroTimer <= 0)
            {
                enemyCurrentState = EnemyState.MOVETOWARDSCRYSTAL;
                isAggroTimerActive = false;
            }
        }
        switch (enemyCurrentState)
        {
            case EnemyState.MOVETOWARDSCRYSTAL:
                currTarget = crystalObject;
                MoveTowardsTarget(currTarget);
                break;

            case EnemyState.MOVETOWARDSPLAYER:
                currTarget = player;
                MoveTowardsTarget(currTarget);
                currentAggroTimer = aggroTime;
                isAggroTimerActive = true;
                break;

            case EnemyState.ATTACKINGCRYSTAL:
                break;

            case EnemyState.ATTACKINGPLAYER:
                break;

            case EnemyState.MOVEAWAY:
                //timer set up to temporarily use MoveAwayFromTarget
                MoveAwayFromTarget(player);
                currentAvoidTimer = avoidTime;
                isAvoidTimerActive = true;
                break;

            case EnemyState.IDLE:
                SetSpeed(0);
                break;
        }
    }

    //[com.cyborgAssets.inspectorButtonPro.ProButton]

    // INDANGER METHOD, similar to aggro. will be used for hivemind/avoidant AI.
    public void InDanger()
    {
        inDanger = true;
        if (enemyAIType == EnemyAIType.AVOIDANT) {

        }
        else if (enemyAIType == EnemyAIType.HIVEMIND)
        {

        }
    }

    // INRANGE METHOD
    /*public void InRange()
    {
        if (attackRange >= Vector3.Distance(transform.position, currTarget.transform.position))
        {
            if (enemyCurrentState == EnemyState.MOVETOWARDSPLAYER)
            {
                enemyCurrentState = EnemyState.ATTACKINGPLAYER;
            }
            if (enemyCurrentState == EnemyState.MOVETOWARDSCRYSTAL)
            {
                enemyCurrentState = EnemyState.ATTACKINGCRYSTAL;
            }
        }
        else
        {
            if (enemyCurrentState == EnemyState.ATTACKINGPLAYER)
            {
                enemyCurrentState = EnemyState.MOVETOWARDSPLAYER;
            }
            if (enemyCurrentState == EnemyState.ATTACKINGCRYSTAL)
            {
                enemyCurrentState = EnemyState.MOVETOWARDSCRYSTAL;
            }
        }
    }*/

    void OnCollisionEnter2D(Collision2D collision)
    {

        //if enemy curr state is MOVETOWARDSCRYSTAL
        //  enemy curr state = MOVETOWARDSPLAYER
        if (enemyCurrentState == EnemyState.MOVETOWARDSCRYSTAL) {
            enemyCurrentState = EnemyState.MOVETOWARDSPLAYER;
            InDanger();
        }

        
    }

}

public enum EnemyAIType
{
    AVOIDANT,
    HIVEMIND,
    NONE
}

public enum EnemyAttackType
{
    MELEE,
    RANGED
}

public enum EnemyState
{
    MOVETOWARDSPLAYER,
    ATTACKINGPLAYER,
    MOVETOWARDSCRYSTAL,
    ATTACKINGCRYSTAL,
    MOVEAWAY,
    IDLE
}
