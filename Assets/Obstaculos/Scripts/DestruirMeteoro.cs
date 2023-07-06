using UnityEngine;

public class DestruirMeteoro : MonoBehaviour
{
    float limiteTelaX;
    float larguraMeteoro;
    float margem = 2f;
    
    void Start()
    {
        limiteTelaX = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z)).x;
        larguraMeteoro = GetComponentInChildren<MeshRenderer>().bounds.size.x / 2;
    }

    void Update()
    {
        if (transform.position.x + larguraMeteoro + margem < limiteTelaX)
            Destroy(gameObject);
    }
}
