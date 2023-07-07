using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorSessao : MonoBehaviour
{
    public void RecarregarCena()
    {
        ContinuarJogo();
        SceneManager.LoadScene(0);
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

    public bool JogoEstaParado()
    {
        return Time.timeScale == 0;
    }
}
