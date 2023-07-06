using UnityEngine;

public class GameOver : MonoBehaviour
{
    Canvas gameOverCanvas;

    void Start()
    {
        gameOverCanvas = GetComponent<Canvas>();
        gameOverCanvas.enabled = false;
    }

    public void Apresentar()
    {
        gameOverCanvas.enabled = true;

        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
