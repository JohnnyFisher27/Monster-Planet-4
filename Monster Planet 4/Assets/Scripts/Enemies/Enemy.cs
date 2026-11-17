using UnityEngine;
using UnityEngine.AI;


public class Enemy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private int health;
    public int maxhealth;
    private NavMeshAgent agent;
    public GameObject player;
    void Start()
    {
        health = maxhealth;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        player = GameManager.Instance.player;
    }



    // Update is called once per frame
    public virtual void Update()
    {
        agent.SetDestination(player.transform.position);
    }

    public virtual void TakeDamage(GameObject target, int damage) 
    {
        health -= damage;
        if (health < 0)
        {
           Destroy(target);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == player)
        {
            Destroy(player);
        }
    }
}
