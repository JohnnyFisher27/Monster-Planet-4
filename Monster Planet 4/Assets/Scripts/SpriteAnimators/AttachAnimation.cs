using UnityEngine;

public class AttachAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private PlayerAnimator animateMe;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animateMe = new PlayerAnimator(_animator);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
