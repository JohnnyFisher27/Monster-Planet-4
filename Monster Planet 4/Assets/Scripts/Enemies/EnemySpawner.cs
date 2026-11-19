using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> enemies = new List<GameObject>();
    private SpriteRenderer spriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
        //GameObject enemy = Instantiate(enemies[Random.Range(0, 2)], this.transform.position, Quaternion.identity);
        //enemy.AddComponent<EnemyManager>();
        StartCoroutine(spawnInterval());
    }

    private IEnumerator spawnInterval() 
    {
        yield return new WaitForSeconds(2f);
        if (GameManager.Instance.MapController.currentChunk && GameManager.Instance.MapController.currentChunk == this.transform.parent.gameObject)
            Instantiate(enemies[Random.Range(0, 2)], this.transform.position, Quaternion.identity);
    }
}
