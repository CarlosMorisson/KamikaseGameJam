using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollider : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            GetComponent<Enemy>().ApplyDamage(other.GetComponent<BulletMove>().Damage);
        }
    }
}
