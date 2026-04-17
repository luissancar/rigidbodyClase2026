using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement2 : MonoBehaviour
{
    [Header("Movimientos")] public float speed;
    public float jumpForce = 6f;


    private Rigidbody rb;
    private Vector2 moveInput;
    [SerializeField] private bool isGrounded = true;

    [SerializeField] private float runMultiplier = 2F;
    [SerializeField] private bool isRunning = false;

    private AnimacionesPlayer2 animacionesPlayer;

    [Header("Ground Check")] [SerializeField]
    private Transform groundCheck;

    [SerializeField] private float groundRadius = 0.25f;


    public AudioSource audioSourcePasos;
    public AudioSource audioSourceSalto;

    private bool canMove = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animacionesPlayer = GetComponent<AnimacionesPlayer2>();

    }

    public void SetCanMove(bool canMo)
    {
        canMove=canMo;
    }
    public void OnGolpear(InputValue value)
    {
        if (value.isPressed && isGrounded)
            animacionesPlayer.Golpear();
    }
    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    public void SonidoPasos()
    {
        bool seEstaMoviendo = moveInput.sqrMagnitude > 0.01f;
        bool deberiaSonar = seEstaMoviendo && isGrounded;

        if (deberiaSonar && !audioSourcePasos.isPlaying)
        {
            audioSourcePasos.Play();
        }
        else if (!deberiaSonar && audioSourcePasos.isPlaying)
        {
            audioSourcePasos.Stop();
        }
    }


public void OnJump(InputValue value)
{
    if (!isGrounded)
        return;
    if (!canMove)
        return;
    if (value.isPressed)
    {
        if (audioSourcePasos.isPlaying)
            audioSourcePasos.Stop();
        audioSourceSalto.Play();
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        animacionesPlayer.AnimacionSaltar1();
    }
}

private void Update()
{
    isRunning = Keyboard.current != null &&
                (Keyboard.current.leftCtrlKey.isPressed ||
                 Keyboard.current.rightCtrlKey.isPressed);


}

private void FixedUpdate()
{
    if (!canMove)
        return;
    CheckGround();
    Vector3 direction = transform.TransformDirection(
        new Vector3(moveInput.x, 0, moveInput.y));
    float currentSpeed = isRunning ? speed * runMultiplier : speed;
    Vector3 velocity = direction * currentSpeed;
    Vector3 newVelocity = new Vector3(velocity.x, rb.linearVelocity.y, velocity.z);
    rb.linearVelocity = newVelocity;
    SonidoPasos();
}

void CheckGround()
{
    Collider[] hits = Physics.OverlapSphere(groundCheck.position, groundRadius);
    bool groundedNow = false;
    foreach (Collider col in hits)
    {
        if (col.gameObject != gameObject) // ignorar el propio jugador
        {
            groundedNow = true;
            break;
        }
    }

    if (groundedNow != isGrounded)
    {

        isGrounded = groundedNow;
        animacionesPlayer.EnSuelo(isGrounded);
    }
}


void OnDrawGizmosSelected()
{
    if (groundCheck == null) return;
    Gizmos.color = Color.yellow;
    Gizmos.DrawWireSphere(groundCheck.position, groundRadius);
}
}