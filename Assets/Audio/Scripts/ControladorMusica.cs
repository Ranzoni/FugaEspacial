using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ControladorMusica : MonoBehaviour
{
    [Tooltip("Prefab com o script de Game Over do jogo")]
    [SerializeField] GameOver gameOver;
    [Tooltip("Prefab com o script de Pause do jogo")]
    [SerializeField] Pause pause;
    
    AudioSource musica;

    void Start()
    {
        musica = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (gameOver.EhGameOver)
            musica.Stop();

        if (pause.EstaPausado)
            musica.Pause();
        else if (!musica.isPlaying)
            musica.Play();
    }
}
