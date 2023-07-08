using UnityEngine;

public class ControladorMusica : MonoBehaviour
{
    GameOver gameOver;
    AudioSource musica;

    void Start()
    {
        gameOver = FindObjectOfType<GameOver>();
        musica = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (gameOver.EhGameOver())
            musica.Stop();
    }
}
