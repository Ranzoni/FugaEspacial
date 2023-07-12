using UnityEngine;

public class Menu : MonoBehaviour
{
    [Tooltip("Prefab com o script de Controlador de Sessão")]
    [SerializeField] ControladorSessao sessao;

    void Awake()
    {
        sessao.PararJogo();
    }
}
