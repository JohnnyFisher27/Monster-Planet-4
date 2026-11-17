using System;
using UnityEngine;

public class PlayerAnimator
{
    private Animator _animator;
    public PlayerAnimator(Animator animator)
    {
       _animator = animator;
    }

    public void Subscribe(PlayerController control)
    {
        control.OnMove += AnimateMovement;
    }

    public void Unsubscribe(PlayerController control)
    {
        control.OnMove -= AnimateMovement;
    }

    private void AnimateMovement(Vector2 move)
    {
        if(move != Vector2.zero)
        {
            _animator.SetBool("isIdle", false);
            _animator.SetInteger("horizontal", (int)Mathf.Round(move.x));
            _animator.SetInteger("vertical", (int)Mathf.Round(move.y));
        } else
        {
            _animator.SetBool("isIdle", true);
        }
    }
}
