using UnityEngine;

public class EfeitoSonoro : MonoBehaviour
{
    [SerializeField] GameObject MotorNaveSFX;
    [SerializeField] GameObject ImpulsoNaveSFX;
    [SerializeField] GameObject explosaoSFX;
    [SerializeField] GameObject itemSFX;
    [SerializeField] GameOver gameOver;
    [SerializeField] Pause pause;

    ControladorImpulso controladorImpulso;
    AudioSource somMotor;
    AudioSource somImpulso;
    AudioSource somItem;

    void Start()
    {
        controladorImpulso = GetComponent<ControladorImpulso>();

        somMotor = RetornarInstanciaAudioSource(MotorNaveSFX);
        somImpulso = RetornarInstanciaAudioSource(ImpulsoNaveSFX);
        somItem = RetornarInstanciaAudioSource(itemSFX);
    }

    AudioSource RetornarInstanciaAudioSource(GameObject prefab)
    {
        var instanciaSFX = Instantiate(prefab, transform);
        return instanciaSFX.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!somMotor.isPlaying)
            ExecutarAudioMotor();

        if (Input.GetButton("Jump") && !somImpulso.isPlaying && controladorImpulso.Quantidade() > 0)
            ExecutarAudioImpulso();

        if (gameOver.EhGameOver() || pause.EstaPausado())
            PararTodosAudios();
    }

    void ExecutarAudioMotor()
    {
        ControlarSom(somMotor, true);
        ControlarSom(somImpulso, false);
    }

    void ExecutarAudioImpulso()
    {
        ControlarSom(somMotor, false);
        ControlarSom(somImpulso, true);
    }

    void PararTodosAudios()
    {
        ControlarSom(somMotor, false);
        ControlarSom(somImpulso, false);
    }

    public void ExecutarAudioExplosao()
    {
        Instantiate(explosaoSFX, transform.position, Quaternion.identity);
    }

    public void ExecutarAudioItem()
    {
        somItem.Play();
    }

    void ControlarSom(AudioSource audio, bool executar)
    {
        if (executar && !audio.isPlaying)
            audio.Play();
        else if (!executar && audio.isPlaying)
            audio.Pause();
    }
}
