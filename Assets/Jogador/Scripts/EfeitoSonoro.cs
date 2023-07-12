using UnityEngine;

public class EfeitoSonoro : MonoBehaviour
{
    [Header("SFX")]
    [Tooltip("Prefab com o som da nave")]
    [SerializeField] GameObject MotorNaveSFX;
    [Tooltip("Prefab com o som de impulso da nave")]
    [SerializeField] GameObject ImpulsoNaveSFX;
    [Tooltip("Prefab com o som de explosão quando a nave colidir com um asteroide")]
    [SerializeField] GameObject explosaoSFX;
    [Tooltip("Prefab com o som de quando um item é capturado")]
    [SerializeField] GameObject itemSFX;
    [Header("UI")]
    [Tooltip("Objeto com o script de Game Over")]
    [SerializeField] GameOver gameOver;
    [Tooltip("Objeto com o script de Pause")]
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

        if (Input.GetButton("Jump") && !somImpulso.isPlaying && controladorImpulso.Quantidade > 0)
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
