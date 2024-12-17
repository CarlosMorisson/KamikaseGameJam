using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnAxis : MonoBehaviour
{
    public enum Axis { X, Y, Z } // Opções de eixo para movimentação
    public Axis movementAxis = Axis.X; // Eixo padrão (X)
    public float speed = 5f; // Velocidade do movimento
    public bool isMoving = true; // Controle para ligar/desligar a movimentação
    public float LifeTime = 10f;
    private void Start()
    {
        Destroy(gameObject, LifeTime);
    }
    private void Update()
    {
        if (isMoving)
        {
            MoveObject();
        }
    }

    public virtual void MoveObject()
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
        transform.Translate(-movement * speed * Time.deltaTime);
    }

}
