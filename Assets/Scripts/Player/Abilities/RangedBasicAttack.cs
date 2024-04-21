using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

// This class handles the ranged basic attack for a game character
public class RangedBasicAttack : Ability 
{
    private Actions actions;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private bool isPlayerShooting;
    [SerializeField] private float enemyFireRate = 5.0f;
    [SerializeField] private float playerFireRate = 0.1f;
    protected float maxLifeTime = 5f;
    [SerializeField] protected int maxDamage = 10; // The damage normal/max dealt by the projectile
    [SerializeField] protected int currentDamage = 10; // current damage the projectile does
    [HideInInspector] public UnityEvent OnAttack;
    private float lastPlayerAttackTime = 0f;
    private float lastEnemyAttackTime = 0f;
    private bool isOnCooldown = true; 
       
    void Awake() { 
        
        actions = GetComponentInParent<Actions>();
        // Add listener for basic attack event when basic attack button is pressed
        actions?.OnBasicAttack.AddListener(ShootIfActive);
      
   
        cooldown = playerFireRate;
    }
    public override void Start()
    {
        NormalProjectileDamage();
    }

    // Method to spawn a projectile
    public void SpawnProjectile(Vector2 moveDirection)  
    {
        GameObject go = Instantiate(projectilePrefab, transform);
      
        go.transform.position = this.transform.position;
        go.transform.rotation = Quaternion.identity;
       
        Projectile projectile = go.GetComponent<Projectile>();

        ProjectileData projectileData = new ProjectileData();
        InitialiazeProjectileData(projectileData, moveDirection);
        projectile.SetProjectileData(projectileData);
        
        go.SetActive(true);
    }

    private void InitialiazeProjectileData(ProjectileData projectileData, Vector2 moveDirection)
    {
        projectileData.ProjectileSpeed = 1000;
        projectileData.ProjectileDamage = currentDamage;
        projectileData.ProjectileLifetime = 5f;
        projectileData.MoveDirection = moveDirection;
        projectileData.Shooter = isPlayerShooting ? Shooter_Enum.PLAYER : Shooter_Enum.ENEMY;
    }

    public void ShootIfActive() {
        if (isOnCoolDown)
            return;

        // If the current mana is greater than or equal to the mana cost, use the ability
        if (GetCurrentMana() >= manaCost)
            AbilityUsage();
    }

    public override void AbilityUsage() {

        if (!isOnCooldown) return; 
        if (Time.time < lastPlayerAttackTime + playerFireRate) return;

        
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Vector2 objectPosition = Camera.main.WorldToScreenPoint(transform.position);
        
        Vector2 direction = (mousePosition - objectPosition).normalized;
        SpawnProjectile(direction);
        UseManaPoints();
        lastPlayerAttackTime = Time.time;
        isOnCooldown = false; 
        StartCoroutine(ResetPlayerShoot());
    }

    public void AttackTarget(Transform currentTarget) 
    {

        if(Time.time < lastEnemyAttackTime + enemyFireRate) return;
        
        OnAttack.Invoke();
        Vector2 directionToTarget = (currentTarget.position - this.transform.parent.transform.position).normalized;
        SpawnProjectile(directionToTarget);

        lastEnemyAttackTime = Time.time;
    }

    // Coroutine to reset canPlayerShoot after the playerFireRate time
    private IEnumerator ResetPlayerShoot()  {
        yield return new WaitForSeconds(playerFireRate);
        isOnCooldown = true;
    }
    public float GetPlayerFireRate() {
        return playerFireRate;
    }
    public GameObject GetBasicAttackPrefab() {
        return projectilePrefab;
    }
    public void SetPlayerFireRate(float rate) {
        playerFireRate = rate;
    }
    
    
    // Getters / Setters
    public int GetMaxProjectileDamage() {
        return maxDamage;
    }

    public void SetMaxProjectileDamage(int amt) {
        maxDamage = amt;
    }

    public void NormalProjectileDamage() {
        currentDamage = maxDamage;
    }

    public void SetCurrentProjectileDamage(int setdamage) {
        currentDamage = setdamage;
    }

    public int GetCurrentProjectileDamage() {
        return currentDamage;
    }
}
