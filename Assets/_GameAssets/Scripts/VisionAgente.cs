﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionAgente : MonoBehaviour
{
    private GameObject player;
    private Animator animator;

    public float distanciaDeteccion;
    public float anguloVision;
    public float distanciaDeteccionAndando;
    public float distanciaDeteccionCorriendo;
    public LayerMask layerMask;
    

    void Start()
    {
        player = GameObject.Find("Remigio");
        animator = player.GetComponentInChildren<Animator>();
    }

    bool IsPlayerAtSightRange()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        return distance < distanciaDeteccion;
    }
    bool IsPlayerVisible()
    {
        bool isVisible = false;
        Vector3 direccion = player.transform.position - transform.position;//Vector de dirección de AGENTE->PLAYER
        Ray rayo = new Ray(transform.position, direccion);
        //Debug.DrawRay(transform.position, direccion, Color.red, 0.1f);
        RaycastHit hitInfo;
        //bool hayContacto = Physics.Raycast(rayo, out hitInfo);
        bool hayContacto = Physics.Raycast(rayo, out hitInfo, Mathf.Infinity, layerMask);
        if (hayContacto && hitInfo.transform.gameObject.name == "Remigio")
        {
            Debug.DrawRay(transform.position, direccion, Color.red, 0.1f);
            isVisible = true;
        }
        return isVisible;
    }
    bool IsPlayerAtSightAngle()
    {
        bool isVisible = false;
        Vector3 direccion = player.transform.position - transform.position;//Vector de dirección de AGENTE->PLAYER
        float angulo = Vector3.Angle(transform.forward, direccion);
        if (angulo < anguloVision)
        {
            isVisible = true;
        }
        return isVisible;
    }

    bool IsPlayerDoingNoise()
    {
        bool hayRuido = false;
        Collider[] cols = null;
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Running"))
        {
            cols = Physics.OverlapSphere(transform.position, distanciaDeteccionCorriendo);
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Brutal To Happy Walking"))
        {
            cols = Physics.OverlapSphere(transform.position, distanciaDeteccionAndando);
        }
        if (cols != null)
        {
            foreach (Collider col in cols)
            {
                if (col.gameObject.name == "Remigio")
                {
                    hayRuido = true;
                }
            }
        }
        return hayRuido;
    }

    void Update()
    {
        if ((IsPlayerAtSightRange() && IsPlayerVisible() && IsPlayerAtSightAngle()) || IsPlayerDoingNoise())
        {
            player.GetComponent<Player>().Detectado();
        }
        else
        {
            player.GetComponent<Player>().NoDetectado();
        }
    }
}
