using UnityEngine;

public class Colisao : MonoBehaviour
{
    [SerializeField] GameObject explosaoSFX;
    [SerializeField] GameObject explosaoVFX;
    [SerializeField] GameObject powerUpSFX;

    ControladorImpulso controladorImpulso;
    GameObject powerUpSFXInstanciado;

    void Start()
    {
        controladorImpulso = GetComponent<ControladorImpulso>();
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
        PowerupFX();
        Destroy(objetoColidiu);
        controladorImpulso.RecuperarImpulso();
    }

    void PowerupFX()
    {
        if (powerUpSFXInstanciado is null)
            powerUpSFXInstanciado = Instantiate(powerUpSFX, transform.position, Quaternion.identity);
        
        powerUpSFXInstanciado.GetComponent<AudioSource>().Play();
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
        DestruirNave();
    }

    void DestruicaoFX()
    {
        Instantiate(explosaoSFX, transform.position, Quaternion.identity);
        Instantiate(explosaoVFX, transform.position, Quaternion.identity);   
    }

    void DestruirNave()
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
