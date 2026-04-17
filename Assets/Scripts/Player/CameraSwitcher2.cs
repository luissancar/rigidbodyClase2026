using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraSwitcher2 : MonoBehaviour
{
    [Header("Cámaras")] public List<Camera> camaras;

    private int indiceActual = 0;


    void Start()
    {
        ActivarSoloEsta(indiceActual);
    }

    private void CambiarCamara()
    {
        indiceActual++;
        if(indiceActual >= camaras.Count)
            indiceActual = 0;
        ActivarSoloEsta(indiceActual);
    }

    public void OnCambioCamara(InputValue value)
    {
        if (value.isPressed)
            CambiarCamara();
    }
    private void ActivarSoloEsta(int index)
    {
        for (int i = 0; i < camaras.Count; i++)
        {
            camaras[i].gameObject.SetActive(i == index);
            if (i == index)
                camaras[i].gameObject.tag = "MainCamera";
            else
                camaras[i].gameObject.tag = "Untagged";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
