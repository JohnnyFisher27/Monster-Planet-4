using System.Runtime.CompilerServices;
using UnityEngine;

public class GameManager
{
    public GameObject player;
    public ProjectileManager projectileManager;
    public CameraController CameraController;
    private static GameManager theInstance;

    public static GameManager Instance { get
        {
            if (theInstance == null)
                theInstance = new GameManager();
            return theInstance;
        }
    }

    private GameManager()
    {
        
    }
}

