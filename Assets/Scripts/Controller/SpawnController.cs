using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public enum SpawnType
    {
        Asteroids,
        Enemy
    };
    public SpawnType spawnType;
    [SerializeField]
    private GameObject[] SpawnList;

    public Transform[] spawnPosition;

    public float spawnInterval = 2f; // Intervalo entre os spawns
    private float timer;

    [SerializeField]
    private int EnemyLocalIndex;
    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnObjects();
            timer = 0f; // Reseta o timer
        }
    }

    // Método para spawnar objetos
    private void SpawnObjects()
    {
        if (SpawnList != null)
        {
            int RandomObject = Random.Range(0, SpawnList.Length-1);
            int RandomPosition = Random.Range(0, spawnPosition.Length-1);
            if(SpawnType.Enemy==spawnType)
                Instantiate(SpawnList[RandomObject], spawnPosition[EnemyLocalIndex].position, Quaternion.identity);
            else
            {
                GameObject game =Instantiate(SpawnList[RandomObject], spawnPosition[RandomPosition].position, Quaternion.identity);
                float RandomScale = Random.Range(1, 3);
                game.transform.localScale = new Vector3(RandomScale, RandomScale, RandomScale);
            }
                 // Spawna na posição 1=
        }
        else
        {
            Debug.LogWarning("ObjectToSpawn não está atribuído!");
        }
    }
}
