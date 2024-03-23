using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using com.cyborgAssets.inspectorButtonPro;
using UnityEngine;
using UnityEngine.Events;

public class HealthPoints : MonoBehaviour
{
    // Max health is set at 100
    [SerializeField] private int MAX_HP = 100;
    [SerializeField] private int currentHP;
    
    private bool isDead = false;
    public UnityEvent OnDead;
    public UnityEvent OnHurt;

    // Character starts with maximum health value
    private void Start()    {
        Respawn();       
    }

    // Add a certain amount of health while character's current health is between 0 and max
    public void AddHealth(int healAmount)   {
        currentHP += healAmount;
        if (currentHP >= MAX_HP)    {
            currentHP = MAX_HP;
        }
    }

    // Remove a certain amount of health while character's current health is above 0
    public void RemoveHealth(int damageAmount)  {
        currentHP -= damageAmount;
        
        // Dying is here:
        if (currentHP <= 0) {
            currentHP = 0;
            if (IsDead() == false)
            {
                isDead = true;
                Die();
            }
            return;
        }
        OnHurt.Invoke();
    }

    // Returns true if character's health is 0
    public bool IsDead()    {
        return isDead;
    }

    public virtual void Die()   {
        
    } 
    [ProButton]
    public virtual void Respawn()   {
        currentHP = MAX_HP;
        isDead = false;
    }
}