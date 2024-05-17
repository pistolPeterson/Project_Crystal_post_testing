using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public enum Shooter_Enum
{
    None,
    PLAYER,
    ENEMY
}
// The Projectile class handles the behavior of projectiles in the game.
public class Projectile : MonoBehaviour
{
    private float projectileSpeed = 1000f; // The speed of the projectile.
    private float lifeTime = 2f; // The maximum lifetime of the projectile.
    public int CurrentDamage { get; set; } // current damage the projectile does
    private Shooter_Enum shooter;
    
    private float timer = 0f; // Timer used to track the lifetime of the projectile.
    private Rigidbody2D rb2D; // The Rigidbody2D component of the projectile.
    private Vector2 moveDirection; // The direction in which the projectile is moving.
    private bool isPlayerShooting = true;

    [HideInInspector] public UnityEvent OnProjectileDisabled;

    private void Awake()    
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        MoveProjectile();

        timer += Time.deltaTime;

       
        if (timer >= lifeTime)
        {
            DisableProjectile();
            timer = 0;
        }
    }

    public void MoveProjectile() 
    {
        float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, Mathf.LerpAngle(transform.rotation.eulerAngles.z, angle, projectileSpeed * Time.deltaTime));
        rb2D.velocity = moveDirection * projectileSpeed * Time.fixedDeltaTime;
    }

    public void SetProjectileData(ProjectileData projectileData)
    {      
        CurrentDamage = projectileData.ProjectileDamage;
        projectileSpeed = projectileData.ProjectileSpeed;
        lifeTime = projectileData.ProjectileLifetime;
        shooter = projectileData.Shooter;
        moveDirection = projectileData.MoveDirection;
      
    }

    // Sets the direction in which the projectile should move.
    public void SetMoveDirection(Vector2 movDir, bool isPlayerShooting)
    {      
        this.isPlayerShooting = isPlayerShooting;
        moveDirection = movDir;
    }

    // OnTriggerEnter2D is called when the Collider2D other enters the trigger (2D physics only).
    private void OnTriggerEnter2D(Collider2D collider)
    {   /*  
        if (collider.gameObject.CompareTag(ENEMY_TAG))
        {
            if (isPlayerShooting) {
                EnemyHealthPoints potentialEnemyHealth = collider.gameObject.GetComponent<EnemyHealthPoints>();

                if (!potentialEnemyHealth) {
                    return;
                }
                potentialEnemyHealth.RemoveHealth(CurrentDamage);

                // Disable the projectile after it has hit an enemy
                DisableProjectile();
            }
        }
        // Check if the projectile has collided with the player
        else if (collider.gameObject.CompareTag(PLAYER_TAG))
        {
            if (isPlayerShooting) {
                return;
            }
            
            HealthPoints potentialPlayerHealth = collider.gameObject.GetComponent<HealthPoints>();

            if (!potentialPlayerHealth) {
                return;
            }

            potentialPlayerHealth.RemoveHealth(CurrentDamage);
            DisableProjectile();
        }
        // Check if the projectile has collided with the crystal
        else if (collider.gameObject.CompareTag(CRYSTAL_TAG) || collider.gameObject.CompareTag(BOSS_CRYSTAL_TAG))
        {
            if (isPlayerShooting) {
                return;
            }
            HealthPoints potentialCrystalHealth = collider.gameObject.GetComponent<HealthPoints>();

            if (!potentialCrystalHealth)    {
                return;
            }
            potentialCrystalHealth.RemoveHealth(CurrentDamage);
            
            //DisableProjectile(); // Uncomment this to not have piercing on crystal.
        }*/

        HealthPoints objectHealthPoints = collider.gameObject.GetComponent<HealthPoints>();
        if (!objectHealthPoints) return;
        switch(objectHealthPoints)
        {
            case PlayerHealthPoints:
                HandlePlayerHit(objectHealthPoints);
                break;
            case EnemyHealthPoints:
                HandleEnemyHit(objectHealthPoints);
                break;
            case CrystalHealthPoints:
                HandleCrystalHit(objectHealthPoints);
                break;
            default:
                Debug.Log("tf is this " + objectHealthPoints);
                break;
        }
    }

    private void HandleCrystalHit(HealthPoints objectHealthPoints)
    {
        if (shooter == Shooter_Enum.PLAYER) return;
        objectHealthPoints.RemoveHealth(CurrentDamage);
    }

    private void HandleEnemyHit(HealthPoints objectHealthPoints)
    {
        if (shooter == Shooter_Enum.ENEMY) return;
        objectHealthPoints.RemoveHealth(CurrentDamage);
    }

    private void HandlePlayerHit(HealthPoints objectHealthPoints)
    {
        if (shooter == Shooter_Enum.PLAYER) return;
        objectHealthPoints.RemoveHealth(CurrentDamage);
    }

    private void DisableProjectile()
    {
        OnProjectileDisabled?.Invoke();
        Destroy(this.gameObject);
    }
    public void SetLifeTime(float life) {
        lifeTime = life;
    }
}
