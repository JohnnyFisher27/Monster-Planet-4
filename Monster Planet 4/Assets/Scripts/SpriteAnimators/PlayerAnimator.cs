using System;
using UnityEngine;

public class PlayerAnimator
{
    private Animator _animator;
    public PlayerAnimator(Animator animator)
    {
       _animator = animator;
        GameManager.Instance.playerController.OnMove += AnimateMovement;
    }

    public void Subscribe()
    {
        GameManager.Instance.playerController.OnMove += AnimateMovement;
    }

    public void Unsubscribe()
    {
        GameManager.Instance.playerController.OnMove -= AnimateMovement;
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
