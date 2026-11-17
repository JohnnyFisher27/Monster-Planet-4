using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void restartGame() 
    {
        GameManager.Instance.state = GameManager.GameState.Play;
        SceneManager.LoadScene("Map");
    }
}
