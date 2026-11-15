using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class MapController : MonoBehaviour
{
    public List<GameObject> terrainChunks;
    public GameObject player;
    public float checkerRadius;
    Vector3 noTerrainPosition;
    public LayerMask terrainMask;
    PlayerController pm;
    void Start()
    {
        pm = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        ChunkChecker();
    }

    void ChunkChecker()
    {
        if(pm.moveDir.x > 0 && pm.moveDir.y == 0) // right
        {
            if (!Physics2D.OverlapCircle(player.transform.position + new Vector3(20,0,0), checkerRadius, terrainMask))
            {
                noTerrainPosition = player.transform.position + new Vector3(20, 0, 0);
                SpawnChunk();
            }
        }
        else if(pm.moveDir.x < 0 && pm.moveDir.y == 0) // left
        {
            if (!Physics2D.OverlapCircle(player.transform.position + new Vector3(-20,0,0), checkerRadius, terrainMask))
            {
                noTerrainPosition = player.transform.position + new Vector3(-20, 0, 0);
                SpawnChunk();
            }
        }
        else if(pm.moveDir.y < 0 && pm.moveDir.x == 0) // down
        {
            if (!Physics2D.OverlapCircle(player.transform.position + new Vector3(0,-20,0), checkerRadius, terrainMask))
            {
                noTerrainPosition = player.transform.position + new Vector3(0, -20, 0);
                SpawnChunk();
            }
        }
        else if(pm.moveDir.y > 0 && pm.moveDir.x == 0) // up
        {
            if (!Physics2D.OverlapCircle(player.transform.position + new Vector3(0,20,0), checkerRadius, terrainMask))
            {
                noTerrainPosition = player.transform.position + new Vector3(0, 20, 0);
                SpawnChunk();
            }
        }
        else if(pm.moveDir.y > 0 && pm.moveDir.x > 0) // right up
        {
            if (!Physics2D.OverlapCircle(player.transform.position + new Vector3(20,20,0), checkerRadius, terrainMask))
            {
                noTerrainPosition = player.transform.position + new Vector3(20, 20, 0);
                SpawnChunk();
            }
        }
        else if(pm.moveDir.y > 0 && pm.moveDir.x < 0) // left up
        {
            if (!Physics2D.OverlapCircle(player.transform.position + new Vector3(-20,20,0), checkerRadius, terrainMask))
            {
                noTerrainPosition = player.transform.position + new Vector3(-20, 20, 0);
                SpawnChunk();
            }
        }
        else if(pm.moveDir.y < 0 && pm.moveDir.x > 0) // right down
        {
            if (!Physics2D.OverlapCircle(player.transform.position + new Vector3(20,-20,0), checkerRadius, terrainMask))
            {
                noTerrainPosition = player.transform.position + new Vector3(20, -20, 0);
                SpawnChunk();
            }
        }
        else if(pm.moveDir.y < 0 && pm.moveDir.x < 0) // left down
        {
            if (!Physics2D.OverlapCircle(player.transform.position + new Vector3(-20,-20,0), checkerRadius, terrainMask))
            {
                noTerrainPosition = player.transform.position + new Vector3(-20, -20, 0);
                SpawnChunk();
            }
        }
    }

    void SpawnChunk()
    {
        int rand = Random.Range(0, terrainChunks.Count);
        Instantiate(terrainChunks[rand], noTerrainPosition, Quaternion.identity);
    }
}
