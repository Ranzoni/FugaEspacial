using UnityEngine;

public class EfeitoVisual : MonoBehaviour
{
    [SerializeField] GameObject fogoPadraoDireitoVFX;
    [SerializeField] GameObject fogoPadraoEsquerdoVFX;
    [SerializeField] GameObject fogoImpulsoDireitoVFX;
    [SerializeField] GameObject fogoImpulsoEsquerdoVFX;
    [SerializeField] GameObject explosaoVFX;

    ControladorImpulso controladorImpulso;

    void Start()
    {
        controladorImpulso = GetComponent<ControladorImpulso>();
    }

    void Update()
    {
        if (Input.GetButton("Jump") && controladorImpulso.Quantidade() > 0)
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
