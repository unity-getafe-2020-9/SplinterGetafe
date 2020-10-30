using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && GameManager.HasKey())
        {
            animator.SetTrigger("Abrir");
        }
    }

    public void PlaySound()
    {
        GetComponent<AudioSource>().Play();
    }
    public void GenerarChispas()
    {
        print("Generando chispas");
    }
}
