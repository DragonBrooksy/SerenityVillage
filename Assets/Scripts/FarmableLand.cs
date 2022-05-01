using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmableLand : MonoBehaviour
{
    protected bool collected;
    public Animator animator;
    private BoxCollider2D boxCollider;

    private void Start()
    {
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Till()
    {
        animator.SetTrigger("Tilled");
    }
}
