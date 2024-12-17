using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy : MoveOnAxis
{
    public EnemySO stats;
    [SerializeField]
    int border;
    //
    [SerializeField]
    float jumpHeight;
    [SerializeField]
    float jumpTime;

    public float Life;
    void Start()
    {
        Destroy(gameObject, 50f);
        Life = stats.Life;
        if(transform.position.y + 1>border)
            transform.DOMoveY(border, 1f, false).SetLoops(-1, LoopType.Yoyo);
        else
            transform.DOMoveY(transform.position.y+ jumpHeight, jumpTime, false).SetLoops(-1, LoopType.Yoyo);
    }

    public override void MoveObject()
    {
        Vector3 movement = Vector3.zero;

        // Define a direção do movimento com base no eixo selecionado
        switch (movementAxis)
        {
            case Axis.X:
                movement = Vector3.right; // Movimento no eixo X
                break;
            case Axis.Y:
                movement = Vector3.up; // Movimento no eixo Y
                break;
            case Axis.Z:
                movement = Vector3.forward; // Movimento no eixo Z
                break;
        }

        // Aplica o movimento
        transform.Translate(-movement * stats.Speed * Time.deltaTime);
    }
    public void ApplyDamage(float damage)
    {
        Life -= damage;
        if (Life < 0)
        {
            Destroy(gameObject);
        }
           
    }
}
