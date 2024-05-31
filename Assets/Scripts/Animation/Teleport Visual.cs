using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportVisual : ShakeVisual
{
    
    [SerializeField] private TeleportAbility teleportAbility;

    void Start()
    {
        flashColor = Color.blue;
        teleportAbility.OnTeleportVisual.AddListener(TriggerShakeVisual);
    }
}
