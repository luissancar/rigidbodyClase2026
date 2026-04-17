using UnityEngine;

public class Bala : MonoBehaviour
{
    public float speed = 20f;
    public float tiempoVida = 4f;
    private Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.linearVelocity = transform.forward * speed;
        Destroy(gameObject, tiempoVida);
    }

    // Update is called once per frame
    void Update()
    {
    }
}