using UnityEngine;
using System.Collections;

public class ThrowAnimation : MonoBehaviour {
    Animator animator;

    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.Play("vor");
        }
    }
}
