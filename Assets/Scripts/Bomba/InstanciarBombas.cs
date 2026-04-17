using System.Collections;
using UnityEngine;

public class InstanciarBombas : MonoBehaviour
{
    [SerializeField] private GameObject prefabBomba;
    [SerializeField] private Transform player;

    [SerializeField] private float distanciaMax = 2f;
    [SerializeField] private float altura = 20f;
    [SerializeField] private float intervalo = 2f;
    public PlayerMovement2 playerMovement;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnContinuo());
    }

    IEnumerator SpawnContinuo()
    {
        while (true)
        {
            if (playerMovement.muerto)
              break;

            Vector2 direccion2D = Random.insideUnitCircle.normalized;
            Vector3 direccion = new Vector3(direccion2D.y, 0, distanciaMax);
            float distancia = Random.Range(distanciaMax, intervalo);
            Vector3 posicionSpawn = player.position + direccion * distancia;
            posicionSpawn.y = altura;


            Instantiate(prefabBomba, posicionSpawn, Quaternion.Euler(180f, 0f, 0f));
            yield return new WaitForSeconds(intervalo);
        }
    }


}