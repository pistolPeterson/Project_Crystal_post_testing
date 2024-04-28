using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyRangedBasicAttack : MonoBehaviour
{

    [SerializeField] private int attackDamage = 1;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform spawnLocation; 
    private Transform targetTransform = null;
    [HideInInspector] public UnityEvent OnEnemyAttack;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Transform hiRaeus = FindObjectOfType<PlayerMovement>().transform;
            AttackTarget(hiRaeus);
        }
    }
    private void SpawnProjectile(Vector2 attackDirection)
    {
        GameObject projectileInstancePrefab = Instantiate(projectilePrefab, spawnLocation.position, Quaternion.identity);
        Projectile projectile = projectileInstancePrefab.GetComponent<Projectile>();
        projectile.SetProjectileData(InitializeProjectileData(attackDirection));
    }

    public void AttackTarget(Transform currentTarget)
    {
        Vector2 directionToTarget = (currentTarget.position - transform.parent.transform.position).normalized;
        SpawnProjectile(directionToTarget);
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


}
