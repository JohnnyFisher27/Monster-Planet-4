using UnityEngine;

public class SpriteManager : MonoBehaviour
{
    private static SpriteManager _instance;
    public static SpriteManager Instance { get { return _instance; } }

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        orderSprites();
    }

    //saw https://www.youtube.com/watch?v=t1UwAGFLmrk and thought this would be useful for layering
    public void orderSprites()
    {
        Object[] spriteRenderers = FindObjectsByType<SpriteRenderer>(FindObjectsSortMode.None);

        foreach(SpriteRenderer renderer in spriteRenderers)
        {
            renderer.sortingOrder = (int)(renderer.transform.position.y * -100);
        }
    }
}
