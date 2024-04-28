using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
/// <summary>
/// Script for handling the enemy visuals
/// </summary>
public class EnemyAnimation : MonoBehaviour
{
    [Header("Enemy Anims")]
    private Animator animator;
    private const string ATTACK_ANIM_TAG = "Attack";
    private const string WALK_ANIM_TAG = "Down Walk";

    [Header("Enemy Visual Configs")]
    [SerializeField] private GameObject enemyVisual;
    [SerializeField] private Canvas hpBarCanvas;
    [SerializeField] private Image hpEnemyFilling;
    [SerializeField] private HealthPoints hp;
    // [SerializeField] private TextMeshProUGUI damageNumText;


    [SerializeField] private EnemyRangedBasicAttack enemyAttack;

    private void Start()
    {
        WeirdRaeusStuffImScaredToRemove();
        animator = GetComponent<Animator>();
         
        enemyAttack.OnEnemyAttack.AddListener(PlayAttackAnim);
    }


    private void Update()
    {
        // enemySpriteRenderer.flipX = enemyAI.GetMovementState() == MovementState.LEFT; 
        /*
        if (enemyAI.GetMovementState() == MovementState.LEFT) {
            enemyVisual.transform.rotation = Quaternion.Euler(0, -180, 0);
        } else {
            enemyVisual.transform.rotation = Quaternion.Euler(0, 0, 0);
        }*/
    }

    private void PlayAttackAnim()
    {
        animator.Play(ATTACK_ANIM_TAG);
    }

    public void UpdateEnemyHealth() {
        hpBarCanvas.enabled = true;
        hpEnemyFilling.fillAmount = (float)hp.GetCurrentHP() / hp.GetMaxHealth();
        //damageNumText.enabled = true;
        //damageNumText.text = "" + hp.GetPreviousDamage();

    }
    private void WeirdRaeusStuffImScaredToRemove()
    { 
        hpBarCanvas.enabled = false;
        //  damageNumText.enabled = false;
        hp.OnHurt.AddListener(UpdateEnemyHealth);
        hpBarCanvas.worldCamera = FindFirstObjectByType<Camera>();
    }


}
