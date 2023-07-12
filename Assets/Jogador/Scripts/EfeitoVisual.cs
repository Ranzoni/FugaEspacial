using UnityEngine;

[RequireComponent(typeof(ControladorImpulso))]
public class EfeitoVisual : MonoBehaviour
{
    [Header("Fogo de Turbina")]
    [Tooltip("Prefab com o sistema de partícula padrão da turbina direita nave")]
    [SerializeField] GameObject fogoPadraoDireitoVFX;
    [Tooltip("Prefab com o sistema de partícula padrão da turbina esquerda nave")]
    [SerializeField] GameObject fogoPadraoEsquerdoVFX;
    [Tooltip("Prefab com o sistema de partícula do impulso da turbina direita nave")]
    [SerializeField] GameObject fogoImpulsoDireitoVFX;
    [Tooltip("Prefab com o sistema de partícula do impulso da turbina esquerda nave")]
    [SerializeField] GameObject fogoImpulsoEsquerdoVFX;
    [Header("Explosão")]
    [Tooltip("Prefab com o sistema de partícula de explosão da nave")]
    [SerializeField] GameObject explosaoVFX;

    ControladorImpulso controladorImpulso;

    void Start()
    {
        controladorImpulso = GetComponent<ControladorImpulso>();
    }

    void Update()
    {
        if (Input.GetButton("Jump") && controladorImpulso.Quantidade > 0)
        {
            ApresentarFogo(false, fogoPadraoDireitoVFX, fogoPadraoEsquerdoVFX);
            ApresentarFogo(true, fogoImpulsoDireitoVFX, fogoImpulsoEsquerdoVFX);
        }
        else
        {
            ApresentarFogo(true, fogoPadraoDireitoVFX, fogoPadraoEsquerdoVFX);
            ApresentarFogo(false, fogoImpulsoDireitoVFX, fogoImpulsoEsquerdoVFX);
        }
    }

    void ApresentarFogo(bool habilitar, GameObject fogoDireito, GameObject fogoEsquerdo)
    {
        fogoDireito.SetActive(habilitar);
        fogoEsquerdo.SetActive(habilitar);
    }

    public void ApresentarExplosao()
    {
        Instantiate(explosaoVFX, transform.position, Quaternion.identity);
    }
}
