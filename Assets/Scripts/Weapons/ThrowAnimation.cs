using UnityEngine;
using System.Collections;

public class ThrowAnimation : MonoBehaviour {
    Animator animator;
    private bool animationStarted;
    public bool Throwing { get; set; }
    public bool Punching { get; set; }

    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
        animationStarted = false;
        Throwing = false;

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && this.animator.GetCurrentAnimatorStateInfo(0).IsName("idle"))
        {
            animator.Play("vor");
            animationStarted = true;
            Punching = true;
        }
        else if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("zuruck") && animationStarted)
        {
            Throwing = true;
            animationStarted = false;
        }
    }
}
