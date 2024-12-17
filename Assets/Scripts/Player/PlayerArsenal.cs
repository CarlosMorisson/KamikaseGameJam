using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening; 
public class PlayerArsenal : MonoBehaviour
{
    [Header ("Shoot")]
    public GameObject projectilePrefab; // Prefab do projétil
    public Transform firePoint; // Ponto de disparo
    public float projectileSpeed = 10f; // Velocidade do projétil
    public float fireRate = 0.5f; // Intervalo entre disparos (em segundos)
    public float damage;

    private float nextFireTime = 0f; // Tempo permitido para o próximo disparo

    [Header("Dash")]
    public float dashDistance = 10f; // Distância do Dash
    public float dashDuration = 0.2f; // Duração do Dash
    public float shakeDuration = 0.5f; // Duração do Shake
    public float shakeStrength = 1f; // Intensidade do Shake
    public int shakeVibrato = 10; // Quantidade de vibrações no Shake
    public float shakeRandomness = 90f; // Aleatoriedade do Shake

    private bool isDashing = false;
    private void Update()
    {
        // Verifica se o botão esquerdo do mouse foi pressionado e se o fire rate permite
        if (Input.GetMouseButtonDown(0) && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate; // Define o tempo para o próximo disparo
        }
        if (Input.GetMouseButtonDown(1) && !isDashing)
        {
            PerformDash();
        }
    }

    private void Shoot()
    {
        if (projectilePrefab != null && firePoint != null)
        {
            // Instancia o projétil no ponto de disparo
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            projectile.GetComponent<BulletMove>().Damage = damage;
            // Adiciona movimento ao projétil, se ele tiver Rigidbody
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = firePoint.forward * projectileSpeed;
            }
        }
        else
        {
            Debug.LogWarning("Prefab ou Fire Point não está configurado!");
        }
    }
    private void PerformDash()
    {
        isDashing = true;

        // Realiza o tremor antes do Dash
        transform.DOShakePosition(shakeDuration, shakeStrength, shakeVibrato, shakeRandomness)
            .OnComplete(() => DashForward()); // Após o tremor, realiza o Dash
    }

    private void DashForward()
    {
        // Calcula a posição final do Dash
        Vector3 dashTarget = transform.position + transform.right * dashDistance;

        // Move o objeto para frente usando DoTween
        transform.DOMove(dashTarget, dashDuration)
            .SetEase(Ease.OutQuad) // Altere a curva de movimento conforme necessário
            .OnComplete(() => isDashing = false); // Libera o Dash quando concluído
    }
}
