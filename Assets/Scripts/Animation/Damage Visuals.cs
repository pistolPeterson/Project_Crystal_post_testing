using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageVisuals : ShakeVisual
{
    private HealthPoints healthPoints;

    void Start()
    {
        flashColor = Color.red;
        healthPoints = GetComponentInParent<HealthPoints>();
        healthPoints.OnHurt.AddListener(TriggerShakeVisual);
    }

    
}
