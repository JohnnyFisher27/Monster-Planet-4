using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> enemies = new List<GameObject>();
    private SpriteRenderer spriteRenderer;
    private Coroutine spawning;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
        //GameObject enemy = Instantiate(enemies[Random.Range(0, 2)], this.transform.position, Quaternion.identity);
        //enemy.AddComponent<EnemyManager>();
        //StartCoroutine(spawnInterval());
    }

    private void Update()
    {
        if (GameManager.Instance.MapController.currentChunk && GameManager.Instance.MapController.currentChunk == this.transform.parent.gameObject)
            if (spawning == null)
                spawning = StartCoroutine(spawnInterval());
    }

    private IEnumerator spawnInterval() 
    {
        yield return new WaitForSeconds(2f);
        if (GameManager.Instance.MapController.currentChunk && GameManager.Instance.MapController.currentChunk == this.transform.parent.gameObject)
            Instantiate(enemies[Random.Range(0, 2)], this.transform.position, Quaternion.identity);

        spawning = null;
    }
}
