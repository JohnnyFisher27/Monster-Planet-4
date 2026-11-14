using System.Runtime.CompilerServices;
using UnityEngine;

public class GameManager
{
    public GameObject player;
    private static GameManager theInstance;

    public CameraController CameraController;
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

