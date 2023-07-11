using UnityEngine;

public class EfeitoSonoro : MonoBehaviour
{
    [SerializeField] GameObject MotorNaveSFX;
    [SerializeField] GameObject ImpulsoNaveSFX;

    AudioSource somMotor;
    AudioSource somImpulso;
    GameOver gameOver;
    Pause pause;
    ControladorImpulso controladorImpulso;

    void Start()
    {
        controladorImpulso = GetComponent<ControladorImpulso>();
        gameOver = FindObjectOfType<GameOver>();
        pause = FindObjectOfType<Pause>();
        var instanciaMotorNaveSFX = Instantiate(MotorNaveSFX, transform);
        somMotor = instanciaMotorNaveSFX.GetComponent<AudioSource>();
        var instanciaImpulsoNaveSFX = Instantiate(ImpulsoNaveSFX, transform);
        somImpulso = instanciaImpulsoNaveSFX.GetComponent<AudioSource>();
        somImpulso.Pause();
    }

    void Update()
    {
        if (!somMotor.isPlaying)
        {
            somMotor.Play();
            somImpulso.Pause();
        }

        if (Input.GetButton("Jump") && !somImpulso.isPlaying && controladorImpulso.Quantidade() > 0)
        {
            somMotor.Pause();
            somImpulso.Play();
        }

        if (gameOver.EhGameOver() || pause.EstaPausado())
        {
            somMotor.Pause();
            somImpulso.Pause();
        }
    }
}
