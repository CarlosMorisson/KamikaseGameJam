using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerSO stats;
    [SerializeField]
    PlayerMove playerMove;
    [SerializeField]
    PlayerArsenal playerArsenal;
    void Start()
    {
        playerMove._speed = stats.MoveSpeed;
        //
        playerArsenal.fireRate = stats.FireRate;
        playerArsenal.projectilePrefab = stats.Projectiles[0];
        playerArsenal.projectileSpeed = stats.FireSpeed;
        playerArsenal.damage = stats.Damage;
    }
    void Update()
    {
        
    }
}
