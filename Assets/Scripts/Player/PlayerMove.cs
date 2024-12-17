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

    // M�todo para tratar entradas
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

    // M�todo para movimentar para cima
    private void MoveUp()
    {
        transform.Translate(Vector3.up * _speed * Time.deltaTime);
    }

    // M�todo para movimentar para baixo
    private void MoveDown()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
    }
}
