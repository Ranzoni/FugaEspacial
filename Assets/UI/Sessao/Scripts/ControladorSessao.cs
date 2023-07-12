using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorSessao : MonoBehaviour
{
    readonly int cenaPrincipal = 1;

    public void IniciarJogo()
    {
        ContinuarJogo();
        SceneManager.LoadScene(cenaPrincipal);
    }

    public void ContinuarJogo()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
    }

    public void PararJogo()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;
    }

    public void FecharJogo()
    {
        Application.Quit();
    }
}
