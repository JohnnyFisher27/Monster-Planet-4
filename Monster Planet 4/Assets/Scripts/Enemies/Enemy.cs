using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;


public class Enemy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int health;
    public int damage;
    private Stats stats;
    private NavMeshAgent agent;
    private GameObject player;
    void Start()
    {
        //configure stats and behaviour
        stats = new Stats(this.gameObject, health, damage);
        stats.OnDeath += Die;
        player = GameManager.Instance.player;
        //pathfinding
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }



    // Update is called once per frame
    public virtual void Update()
    {
        if (GameManager.Instance.state == GameManager.GameState.Play)
            agent.SetDestination(player.transform.position);
    }

    private void Die()
    {
        EventBus.Instance.DoDestroy(this.gameObject);
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == player)
        {
            SceneManager.LoadScene("Restart");
            EventBus.Instance.DoDamage(GameManager.Instance.player, stats.attack);
        }
    }
}
