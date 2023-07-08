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
}
