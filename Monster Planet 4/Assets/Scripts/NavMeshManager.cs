using NavMeshPlus.Components;
using UnityEngine;

public class NavMeshManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private NavMeshSurface NavMeshSurface;
    public void rebakeMesh() 
    {
        //Debug.Log("Rebaked");
        NavMeshSurface.BuildNavMesh();
    }
}
