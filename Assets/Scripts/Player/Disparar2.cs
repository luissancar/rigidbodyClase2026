using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Disparar2 : MonoBehaviour
{
    [Header("Prefab Bala")] public GameObject prefabBala;

    [Header("Punta de disparo")] public Transform puntoDisparo;

    public GameObject arma;
    public float retraso = 0.5f;
    public AnimacionesPlayer2 animator;

    public AudioSource audioSource;

    public GameObject mano;

    public GameObject espalda;

    private void Disparado()
    {
        if (prefabBala == null || puntoDisparo == null)
            return;
        ArmaEnMano();
        animator.AnimacionDisparar();
        audioSource.Play();
        StartCoroutine(DispararDelay());
    }

    IEnumerator DispararDelay()
    {
        yield return new WaitForSeconds(retraso);
        GameObject bala = Instantiate(prefabBala, puntoDisparo.position, puntoDisparo.rotation);
        ArmaEnEspalda();
    }

    public void OnDisparar(InputValue value)
    {
        if (value.isPressed)
            Disparado();
    }

    public void ArmaEnMano()
    {
        arma.transform.SetParent(mano.transform);
        arma.transform.localPosition = new Vector3(-0.1184257f, -0.0626f, -0.1463f);
        arma.transform.localRotation = Quaternion.Euler(-46.683f,-67.14f,-15.9f);
    }

    public void ArmaEnEspalda()
    {
        arma.transform.SetParent(espalda.transform);
        arma.transform.localPosition = new Vector3(0.0214316f, 0.5055459f, -0.43f);
        arma.transform.localRotation = Quaternion.Euler(-124.132f,-138.582f,-68.276f);
    }

}