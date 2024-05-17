using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyRangedBasicAttack : MonoBehaviour
{

    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private int attackDamage = 1;
    [SerializeField] private float attackSpeed = 1.5f;
    [SerializeField] private Transform spawnLocation; 
    [HideInInspector] public UnityEvent OnEnemyAttack;
    private float lastEnemyAttackTime = 0f;
  
    private void SpawnProjectile(Vector2 attackDirection)
    {
        GameObject projectileInstancePrefab = Instantiate(projectilePrefab, spawnLocation.position, Quaternion.identity);
        Projectile projectile = projectileInstancePrefab.GetComponent<Projectile>();
        projectile.SetProjectileData(InitializeProjectileData(attackDirection));
    }

    public void AttackTarget(Transform currentTarget)
    {
        Vector2 directionToTarget = (currentTarget.position - transform.parent.transform.position).normalized;
        DelayedSpawn(directionToTarget);
        OnEnemyAttack?.Invoke();
    }

    private ProjectileData InitializeProjectileData( Vector2 moveDirection)
    {
        ProjectileData projectileData = new ProjectileData();
        projectileData.ProjectileSpeed = 1000;
        projectileData.ProjectileDamage = attackDamage;
        projectileData.ProjectileLifetime = 5f;
        projectileData.MoveDirection = moveDirection;
        projectileData.Shooter = Shooter_Enum.ENEMY;

        return projectileData;
    }
    public void DelayedSpawn(Vector2 dirToTarget) {
        if (Time.time < lastEnemyAttackTime + attackSpeed) return;
        SpawnProjectile(dirToTarget);
        lastEnemyAttackTime = Time.time;
    }

}
