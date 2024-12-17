using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MoveOnAxis
{
    public float Damage;
    
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
        transform.Translate(movement * speed * Time.deltaTime);
    }
}
