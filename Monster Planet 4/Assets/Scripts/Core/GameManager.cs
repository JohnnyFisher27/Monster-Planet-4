using System.Runtime.CompilerServices;
using UnityEngine;

public class GameManager
{
    public enum GameState
    {
        Play,
        Pause,
        GameOver
    }
    public GameState state;
    public GameObject player;
    public PlayerController playerController;
    public ProjectileManager projectileManager;
    public CameraController CameraController;
    public MapController MapController;
    private static GameManager theInstance;

    public int chunksLoaded;
    public static GameManager Instance { get
        {
            if (theInstance == null)
                theInstance = new GameManager();
            return theInstance;
        }
    }

    private GameManager()
    {
        state = GameState.Play;
    }
}

