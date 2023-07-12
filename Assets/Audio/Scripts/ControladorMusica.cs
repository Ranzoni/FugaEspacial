using UnityEngine;

public class ControladorMusica : MonoBehaviour
{
    GameOver gameOver;
    AudioSource musica;
    Pause pause;

    void Start()
    {
        gameOver = FindObjectOfType<GameOver>();
        musica = GetComponent<AudioSource>();
        pause = FindObjectOfType<Pause>();
    }

    void Update()
    {
        if (gameOver.EhGameOver)
            musica.Stop();

        if (pause.EstaPausado())
            musica.Pause();
        else if (!musica.isPlaying)
            musica.Play();
    }
}
