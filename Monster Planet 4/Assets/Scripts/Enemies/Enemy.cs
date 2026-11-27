using System.Collections;
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
    private float distance;
    private bool pouncing;
    [SerializeField] private bool isMantis;
    [SerializeField] private float strafeDistance = 3f;
    [SerializeField] private float strafeInterval = 1f;
    [SerializeField] private float leapDuration = 0.3f;
    [SerializeField] private float leapHeight = 2f;
    [SerializeField] private Animator animator;
    void Start()
    {
        //configure stats and behaviour
        stats = new Stats(this.gameObject, health, damage);
        stats.OnDeath += Die;
        player = GameManager.Instance.player;
        pouncing = false;
        //pathfinding
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.speed = 4.5f;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (GameManager.Instance.state == GameManager.GameState.Play)
            distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance <= 5 && isMantis && !pouncing)
        {
            agent.isStopped = true;
            pouncing = true;
            StartCoroutine(Leap());
        }
        else if (distance > 5 || !isMantis)
        {
            agent.SetDestination(player.transform.position);
            
        }

        Vector3 direction = (player.transform.position - transform.position).normalized;
        if (direction.y < 0)
        {
            animator.SetBool("isTurnedDown", true);
        }
        else
        {
            animator.SetBool("isTurnedDown", false);
        }
        
        if (direction.x < 0)
        {
           animator.SetBool("isTurnedLeft", true);
        }
        else
        {
           animator.SetBool("isTurnedLeft", false);
        }

        if (direction.x > 0)
        {
            animator.SetBool("isTurnedRight", true);
        }
        else
        {
            animator.SetBool("isTurnedRight", false);
        }

        if (direction.y > 0)
        {
            animator.SetBool("isTurnedUp", true);
        }
        else
        {
            animator.SetBool("isTurnedUp", false);
        }
        
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

    private IEnumerator Leap()
    {
        yield return new WaitForSeconds(0.5f);
        Vector3 start = transform.position;
        Vector3 end = player.transform.position;

        float elapsed = 0f;

        while (elapsed < leapDuration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / leapDuration);
            float progress = 1f - Mathf.Pow(1f - t, 2f);
            Vector3 position = Vector3.Lerp(start, end, progress);
            position.y += 4f * leapHeight * t * (1f - t);
            transform.position = position;
            yield return null;
        }

        animator.SetTrigger("isLeaping");
        transform.position = end;
        yield return new WaitForSeconds(1.25f);
        agent.isStopped = false;
        pouncing = false;
    }
}
