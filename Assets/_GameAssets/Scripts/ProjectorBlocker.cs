using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectorBlocker : MonoBehaviour
{
    Quaternion rotacionInicial;
    Quaternion rotacion;

    private void Start()
    {
        rotacionInicial = transform.rotation;
    }

    void Update()
    {
        rotacion = Quaternion.Euler(rotacionInicial.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        transform.rotation = rotacion;
    }
}
