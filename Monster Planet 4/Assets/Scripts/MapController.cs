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
    //PlayerMovement pm;
    void Start()
    {
        //pm = player.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        ChunkChecker();
    }

    void ChunkChecker()
    {
        //if(pm.moveDir.x < 0 && pm.moveDir.y == 0)
    }
}
