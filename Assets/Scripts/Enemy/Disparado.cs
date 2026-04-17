using System;
using UnityEngine;

public class Disparado : MonoBehaviour
{
    Animator animator;
    private bool muerto = false;
    public AudioSource audioSource;
    public AnimacionesPlayer2 animaciones;

    [SerializeField] private GameObject efectoSangre;

    [SerializeField] private Transform puntoSangre;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        muerto = false;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (muerto)
            return;
        if (other.gameObject.tag == "bala")
        {
            audioSource.Play();

           // Vector3 pos = other.transform.position;
            //GameObject sangre = Instantiate(efectoSangre, puntoSangre.transform.localPosition, Quaternion.identity);

            Vector3 posicion = other.contacts[0].point;
            GameObject sangre = Instantiate(efectoSangre, posicion, Quaternion.identity);


            sangre.transform.SetParent(transform.GetChild(1));
            Destroy(other.gameObject);
            Destroy(sangre, 10f);
            muerto = true;

            animator.SetTrigger("Muerto");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (muerto)
            return;
        if (other.gameObject.tag == "mano" && animaciones.GolpeoPosible())
        {
            audioSource.Play();
            muerto = true;
            animator.SetTrigger("Muerto");
        }
    }
}