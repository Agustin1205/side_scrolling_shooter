using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    public float invisibleDuration = 5f; // Duración de la invisibilidad
    private bool consumed = false; // Estado de si ha sido consumido o no
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // Movimiento del power-up
        rb.velocity = new Vector3(-0.7f, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !consumed)
        {
            // Desactivar el renderizador del jugador
            Renderer playerRenderer = other.GetComponent<Renderer>();
            if (playerRenderer != null)
            {
                playerRenderer.enabled = false;
            }

            // Establecer una corrutina para hacer visible al jugador después de la duración de la invisibilidad
            StartCoroutine(MakePlayerVisibleAfterDelay(other.gameObject));
            consumed = true;
        }
    }

    private IEnumerator MakePlayerVisibleAfterDelay(GameObject player)
    {
        // Esperar la duración de la invisibilidad
        yield return new WaitForSeconds(invisibleDuration);

        // Activar el renderizador del jugador nuevamente
        Renderer playerRenderer = player.GetComponent<Renderer>();
        if (playerRenderer != null)
        {
            playerRenderer.enabled = true;
        }
    }
}
