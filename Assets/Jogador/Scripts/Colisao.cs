using UnityEngine;

[RequireComponent(typeof(ControladorImpulso), typeof(EfeitoSonoro), typeof(EfeitoVisual))]
public class Colisao : MonoBehaviour
{
    ControladorImpulso controladorImpulso;
    EfeitoSonoro efeitoSonoro;
    EfeitoVisual efeitoVisual;

    void Start()
    {
        controladorImpulso = GetComponent<ControladorImpulso>();
        efeitoSonoro = GetComponent<EfeitoSonoro>();
        efeitoVisual = GetComponent<EfeitoVisual>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstaculo"))
            ProcessarColisaoObstaculo(other.gameObject);

        if (other.CompareTag("Item"))
            ProcessarColisaoItem(other.gameObject);
    }

    void ProcessarColisaoItem(GameObject objetoColidiu)
    {
        Destroy(objetoColidiu);
        efeitoSonoro.ExecutarAudioItem();
        controladorImpulso.RecuperarImpulso();
    }

    void ProcessarColisaoObstaculo(GameObject objetoColidiu)
    {
        Destroy(objetoColidiu);
        ProcessarDestruicao();
        ExecutarGameOver();
    }

    void ProcessarDestruicao()
    {
        DestruicaoFX();
        RemoverNave();
    }

    void DestruicaoFX()
    {
        efeitoSonoro.ExecutarAudioExplosao();
        efeitoVisual.ApresentarExplosao();
    }

    void RemoverNave()
    {
        var listCapsuleCollider = GetComponents<CapsuleCollider>();
        foreach (var capsuleCollider in listCapsuleCollider)
            capsuleCollider.enabled = false;

        var boxCollider = GetComponent<BoxCollider>();
        boxCollider.enabled = false;

        var corpo = GetComponentInChildren<Transform>();
        corpo.gameObject.SetActive(false);
    }

    void ExecutarGameOver()
    {
        var gameOver = FindObjectOfType<GameOver>();
        gameOver.Apresentar();
    }
}
