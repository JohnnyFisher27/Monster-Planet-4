using Unity.VisualScripting;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Stats stats;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.stats = new Stats(this.gameObject, 10, 100);
        stats.OnDeath += Die;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Die()
    {
        EventBus.Instance.DoDestroy(this.gameObject);
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == GameManager.Instance.player)
        {
            EventBus.Instance.DoDamage(GameManager.Instance.player, stats.attack);
        }
    }
}
