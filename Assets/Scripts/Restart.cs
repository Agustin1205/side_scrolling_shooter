using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    private void Update()
    {
        CheckForRestartInput();
    }

    private void CheckForRestartInput()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartLevel();
        }
    }

    private void RestartLevel()
    {
        // Reactivar al jugador si está desactivado
        if (!Controller_Player._Player.gameObject.activeSelf)
        {
            Controller_Player._Player.gameObject.SetActive(true);
        }

        // Reanudar el tiempo si se pausó
        Time.timeScale = 1f;

        // Reiniciar la escena actual
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}