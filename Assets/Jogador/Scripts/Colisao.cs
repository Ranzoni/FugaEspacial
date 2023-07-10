using UnityEngine;

public class Colisao : MonoBehaviour
{
    [SerializeField] GameObject explosaoSFX;
    [SerializeField] GameObject explosaoVFX;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Obstaculo")
            return;

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
