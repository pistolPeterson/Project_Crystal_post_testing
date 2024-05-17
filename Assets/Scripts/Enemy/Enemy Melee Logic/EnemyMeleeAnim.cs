using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAnim : MonoBehaviour
{
    [SerializeField] private GameObject meleeHitBox;

    private void Start()
    {
        DisableHitbox();
    }
    public void EnableHitbox()
    {
        meleeHitBox.SetActive(true);
    }

    public void DisableHitbox()
    {
        meleeHitBox.SetActive(false);
    }
}
