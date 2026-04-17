using System;
using UnityEngine;

public class AnimacionesPlayer2 : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody rb;

    public bool puedeGolpear;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (!animator)
            animator = GetComponent<Animator>();
        if (!rb)
            rb = GetComponent<Rigidbody>();
        puedeGolpear = false;
    }

    public void PuedoGolpear()
    {
        Debug.Log("Puedo Golpear");
        puedeGolpear = true;
    }
    public void NoPuedoGolpear()
    {
        Debug.Log("No puedo Golpear");
        puedeGolpear = false;
    }

    public bool GolpeoPosible()
    {
        return puedeGolpear;
    }
    public void Golpear()
    {
        animator.SetTrigger("Golpear");
    }
    public void AnimacionDisparar()
    {
        animator.SetTrigger("Disparar");
    }
    public void AnimacionSaltar1()
    {
        animator.SetTrigger("Saltar1");
    }

    public void EnSuelo(bool value)
    {
        animator.SetBool("EnSuelo", value);
    }
    public void AnimacionSaltar2()
    {
        animator.SetTrigger("Saltar2");
    }
    private void FixedUpdate()
    {
        Vector3 vWorld = rb.linearVelocity;
        Vector3 vLocal = transform.InverseTransformDirection(vWorld);
        animator.SetFloat("X", vLocal.x);
        animator.SetFloat("Y", vLocal.z);
        animator.SetFloat("VelVertical", vLocal.y);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
