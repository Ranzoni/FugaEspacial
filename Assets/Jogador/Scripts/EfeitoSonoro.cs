using UnityEngine;

public class EfeitoSonoro : MonoBehaviour
{
    [SerializeField] AudioSource SomNave;
    [SerializeField] AudioSource SomImpulso;

    void Start()
    {
        SomNave.Play();
    }
}
