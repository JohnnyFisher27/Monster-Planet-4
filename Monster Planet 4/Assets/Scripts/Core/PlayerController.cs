using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public event Action<Vector2> OnMove;
    public Stats stats;
    private GameObject player;
    private Rigidbody2D body;
    [SerializeField] private float speed = 5.0f;

    //help from example https://docs.unity3d.com/6000.6/Documentation/ScriptReference/CharacterController.Move.html
    [Header("Input Actions")]
    [SerializeField] private InputActionReference moveInput;
    [SerializeField] private InputActionReference mouseInput;
    [SerializeField] private InputActionReference menuInput;
    //how to animate https://youtu.be/AdQz2wStdLY
    [SerializeField] private Animator _animator;

    private PlayerAnimator animateMe;
    public Vector2 moveDir;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        //set gamemanager player model
        GameManager.Instance.player = this.gameObject;
    }
    void Start()
    {
        player = GameManager.Instance.player;
        body = player.GetComponent<Rigidbody2D>();
        stats = new Stats(player, 100, 10);
        stats.OnDeath += GameOver;
        animateMe = new PlayerAnimator(_animator);
        animateMe.Subscribe(this);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = moveInput.action.ReadValue<Vector2>();
        Vector3 move = input.normalized * speed;

        float moveX = move.x * Time.deltaTime;
        float moveY = move.y * Time.deltaTime;
        moveDir = new Vector2(moveX, moveY);

        body.linearVelocity = move;

        if (mouseInput.action.triggered)
            Shoot();

        //if (input != Vector2.zero)
            OnMove?.Invoke(input);

        //if(menuInput.action.triggered)
        //{
        //    MenuManager.Instance.SwitchScene("Main Menu");
        //}
    }

    private void Shoot()
    {
        GameManager.Instance.projectileManager.Fire(transform.position, Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()) - transform.position, stats.attack, body.linearVelocity);
    }

    private void GameOver()
    {
        //gameover trigger here
    }
}
