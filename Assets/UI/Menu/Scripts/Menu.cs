using UnityEngine;

public class Menu : MonoBehaviour
{
    Canvas menuCanvas;
    ControladorSessao sessao;

    void Awake()
    {
        sessao = FindObjectOfType<ControladorSessao>();
        sessao.PararJogo();
    }

    void Start()
    {
        menuCanvas = GetComponent<Canvas>();
    }

    public void Iniciar()
    {
        menuCanvas.enabled = false;

        sessao.ContinuarJogo();
    }
}
