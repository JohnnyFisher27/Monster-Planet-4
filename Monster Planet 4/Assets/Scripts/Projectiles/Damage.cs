using UnityEngine;

public class Damage : MonoBehaviour //projectile damage, specifically, don't use it for other things :p
{
    public int damage;
    public Vector2 direction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Rigidbody2D>().linearVelocity = direction * 10f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject != GameManager.Instance.player)
        {
            EventBus.Instance.DoDamage(collision.gameObject, damage);
            Destroy(this.gameObject);
        }
    }
}
