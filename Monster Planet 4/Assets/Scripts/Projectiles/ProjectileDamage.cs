using UnityEngine;

public class ProjectileDamage : MonoBehaviour //projectile damage, specifically, don't use it for other things :p
{
    public int damage;
    public Vector2 direction;
    public Vector2 playerMomentum;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Rigidbody2D>().linearVelocity = (direction * 10f) + (direction * playerMomentum.magnitude);
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
