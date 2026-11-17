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
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 targetPosition = Vector2.Lerp(GameManager.Instance.player.transform.position, worldPosition, 0.5f);
        _camera.transform.position = new Vector3(targetPosition.x, targetPosition.y, -10f);
    }
}
