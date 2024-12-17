using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerSO : ScriptableObject
{

    public float MoveSpeed;
    public float FireRate;
    public float Damage;
    public float FireSpeed;

    public List<GameObject> Projectiles = new();
}
