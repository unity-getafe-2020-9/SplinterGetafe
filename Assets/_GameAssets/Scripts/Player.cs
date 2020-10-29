using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    public GameObject bolaDeteccion;

    public float walkSpeed;
    public float runSpeed;
    private float speed;
    public float angularSpeed;
    float z;
    float x;
    Animator animator;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        speed = walkSpeed;
    }
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Knocked Out"))
        {
            animator.SetFloat("z", 0);
            return;
        }
        if (z > 0)
        {
            Avanzar();
        }
        if (Mathf.Abs(x) > 0)
        {
            Girar();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Correr();
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            PararCorrer();
        }
    }
    void Avanzar()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        animator.SetFloat("z", z);
    }
    void Girar()
    {
        transform.Rotate(0, x * angularSpeed * Time.deltaTime, 0);
    }
    void Correr()
    {
        animator.SetBool("Running", true);
        speed = runSpeed;
    }
    void PararCorrer()
    {
        animator.SetBool("Running", false);
        speed = walkSpeed;
    }
    void Caer()
    {
        animator.SetTrigger("Zasca");
    }
    public void Detectado()
    {
        bolaDeteccion.SetActive(true);
    }
    public void NoDetectado()
    {
        bolaDeteccion.SetActive(false);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Running"))
        {
            Caer();
            //PararCorrer();
        }
        
    }
}
