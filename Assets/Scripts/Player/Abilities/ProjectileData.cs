
using UnityEngine;

//projectile data
//shooter, move direction, damage, speed, lifetime
public class ProjectileData
{
    public Shooter_Enum Shooter { get; set; }
    public Vector2 MoveDirection { get; set; }
    public int ProjectileDamage { get; set; }
    public int ProjectileSpeed { get; set; }
    public float ProjectileLifetime { get; set; }
}
