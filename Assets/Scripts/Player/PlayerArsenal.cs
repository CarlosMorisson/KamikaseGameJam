using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening; 
public class PlayerArsenal : MonoBehaviour
{
    [Header ("Shoot")]
    public GameObject projectilePrefab; // Prefab do proj�til
    public Transform firePoint; // Ponto de disparo
    public float projectileSpeed = 10f; // Velocidade do proj�til
    public float fireRate = 0.5f; // Intervalo entre disparos (em segundos)
    public float damage;

    private float nextFireTime = 0f; // Tempo permitido para o pr�ximo disparo

    [Header("Dash")]
    public float dashDistance = 10f; // Dist�ncia do Dash
    public float dashDuration = 0.2f; // Dura��o do Dash
    public float shakeDuration = 0.5f; // Dura��o do Shake
    public float shakeStrength = 1f; // Intensidade do Shake
    public int shakeVibrato = 10; // Quantidade de vibra��es no Shake
    public float shakeRandomness = 90f; // Aleatoriedade do Shake

    private bool isDashing = false;
    private void Update()
    {
        // Verifica se o bot�o esquerdo do mouse foi pressionado e se o fire rate permite
        if (Input.GetMouseButtonDown(0) && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate; // Define o tempo para o pr�ximo disparo
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
            // Instancia o proj�til no ponto de disparo
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            projectile.GetComponent<BulletMove>().Damage = damage;
            // Adiciona movimento ao proj�til, se ele tiver Rigidbody
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = firePoint.forward * projectileSpeed;
            }
        }
        else
        {
            Debug.LogWarning("Prefab ou Fire Point n�o est� configurado!");
        }
    }
    private void PerformDash()
    {
        isDashing = true;

        // Realiza o tremor antes do Dash
        transform.DOShakePosition(shakeDuration, shakeStrength, shakeVibrato, shakeRandomness)
            .OnComplete(() => DashForward()); // Ap�s o tremor, realiza o Dash
    }

    private void DashForward()
    {
        // Calcula a posi��o final do Dash
        Vector3 dashTarget = transform.position + transform.right * dashDistance;

        // Move o objeto para frente usando DoTween
        transform.DOMove(dashTarget, dashDuration)
            .SetEase(Ease.OutQuad) // Altere a curva de movimento conforme necess�rio
            .OnComplete(() => isDashing = false); // Libera o Dash quando conclu�do
    }
}
