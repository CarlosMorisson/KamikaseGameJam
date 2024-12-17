using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [HideInInspector]
    public float _speed { get; set; }
    private void Update()
    {
        HandleInput();
    }

    // Método para tratar entradas
    private void HandleInput()
    {
        if (Input.GetKey(KeyCode.W)) // Move para cima
        {
            MoveUp();
        }
        else if (Input.GetKey(KeyCode.S)) // Move para baixo
        {
            MoveDown();
        }
    }

    // Método para movimentar para cima
    private void MoveUp()
    {
        transform.Translate(Vector3.up * _speed * Time.deltaTime);
    }

    // Método para movimentar para baixo
    private void MoveDown()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
    }
}
