using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Action OnMove;
    private GameObject player;
    private Rigidbody2D body;
    [SerializeField] private float speed = 5.0f;

    //help from example https://docs.unity3d.com/6000.6/Documentation/ScriptReference/CharacterController.Move.html
    [Header("Input Actions")]
    [SerializeField] private InputActionReference moveInput;
    [SerializeField] private InputActionReference menuInput;

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
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = moveInput.action.ReadValue<Vector2>();
        Vector3 move = input.normalized * speed;

        body.linearVelocity = move;

        if (input != Vector2.zero)
            OnMove?.Invoke();

        //if(menuInput.action.triggered)
        //{
        //    MenuManager.Instance.SwitchScene("Main Menu");
        //}
    }
}
