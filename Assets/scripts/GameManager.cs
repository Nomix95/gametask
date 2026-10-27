using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject endPanel;
    public TMP_Text endText;
    public bool gameOver = false;

    void Start()
    {
        // Time stays frozen across scene loads, so always unfreeze on start.
        Time.timeScale = 1f;
        gameOver = false;
        if (endPanel != null)
        {
            endPanel.SetActive(false);
        }
    }

    void Update()
    {
        if (!gameOver)
        {
            return;
        }

        bool restart = false;
        if (Keyboard.current != null && Keyboard.current.rKey.wasPressedThisFrame)
        {
            restart = true;
        }
        // Tap or click also restarts (so it works on Android too).
        if (Pointer.current != null && Pointer.current.press.wasPressedThisFrame)
        {
            restart = true;
        }

        if (restart)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void EndGame(string message)
    {
        if (gameOver)
        {
            return;
        }
        gameOver = true;
        if (endText != null)
        {
            endText.text = message + "\nPress R to restart";
        }
        if (endPanel != null)
        {
            endPanel.SetActive(true);
        }
        // Freeze the world: player, hazards and camera stop moving.
        Time.timeScale = 0f;
    }
}
