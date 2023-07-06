using UnityEngine;

public class Colisao : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Obstaculo")
            return;

        Destroy(gameObject);

        var gameOver = FindObjectOfType<GameOver>();
        gameOver.Apresentar();
    }
}
