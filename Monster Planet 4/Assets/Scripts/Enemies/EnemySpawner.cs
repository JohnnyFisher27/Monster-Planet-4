using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject enemy = Instantiate(enemyPrefab, this.transform.position, Quaternion.identity);
        enemy.AddComponent<EnemyManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
