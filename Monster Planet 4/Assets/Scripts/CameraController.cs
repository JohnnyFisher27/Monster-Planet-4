using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    private Camera _camera;
    void Awake()
    {
        GameManager.Instance.CameraController = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _camera = this.GetComponent<Camera>();
    }

    // Update is called once per frame
    void FixedUpdate()
    { //https://discussions.unity.com/t/get-mouse-position-on-screen-from-the-center/17717 solution to pouse positioning
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Vector2 positionFromCenter = new Vector2(mousePosition.x - Screen.width / 2, mousePosition.y - Screen.height / 2);
        _camera.transform.position = Vector2.Lerp(GameManager.Instance.player.transform.position, positionFromCenter, 0.01f);
    }
}
