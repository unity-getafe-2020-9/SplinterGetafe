using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arcade : MonoBehaviour
{
    [Range(0,0.02f)]
    public float inverseSpeed = 0.01f;
    public GameObject targetCamera;
    Vector3 posicionInicial;
    Vector3 posicionFinal;
    Quaternion rotacionInicial;
    Quaternion rotacionFinal;

    private void Start()
    {
        posicionFinal = targetCamera.transform.position;
        rotacionFinal = targetCamera.transform.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            posicionInicial = Camera.main.transform.position;
            rotacionInicial = Camera.main.transform.rotation;
            Camera.main.transform.SetParent(null);
        }
        StartCoroutine("AcercarCamara");
    }
    
    IEnumerator AcercarCamara()
    {
        for(float i = 0; i < 1; i=i+0.01f)
        {
            Vector3 nuevaPosicion = Vector3.Lerp(posicionInicial, posicionFinal, i);
            Quaternion nuevoAngulo = Quaternion.Lerp(rotacionInicial, rotacionFinal, i);
            Camera.main.transform.position = nuevaPosicion;
            Camera.main.transform.rotation = nuevoAngulo;
            yield return new WaitForSeconds(inverseSpeed);
        }
    }
}
