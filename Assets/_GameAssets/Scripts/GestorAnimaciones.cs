using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GestorAnimaciones : MonoBehaviour
{
    Animator animator;
    NavMeshAgent nma;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        nma = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        if (Mathf.Abs(nma.velocity.magnitude) <= 0.05f)
        {
            animator.SetBool("Idle", true);
        }
        else
        {
            animator.SetBool("Idle", false);
        }
    }
}
