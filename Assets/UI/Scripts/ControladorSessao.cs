using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorSessao : MonoBehaviour
{
    public void RecarregarCena()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void FecharJogo()
    {
        Application.Quit();
    }
}
