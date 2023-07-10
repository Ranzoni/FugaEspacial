using UnityEngine;

public class EfeitoSonoro : MonoBehaviour
{
    [SerializeField] GameObject MotorNaveSFX;

    AudioSource somMotor;
    GameOver gameOver;
    Pause pause;

    void Start()
    {
        gameOver = FindObjectOfType<GameOver>();
        pause = FindObjectOfType<Pause>();
        var instanciaMotorNaveSFX = Instantiate(MotorNaveSFX, transform);
        somMotor = instanciaMotorNaveSFX.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!somMotor.isPlaying)
            somMotor.Play();

        if (gameOver.EhGameOver() || pause.EstaPausado())
            somMotor.Pause();
    }
}
