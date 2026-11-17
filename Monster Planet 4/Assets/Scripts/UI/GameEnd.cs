using TMPro;
using UnityEngine;

public class GameEnd : MonoBehaviour
{
    private GameObject gameOverDisplay;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.state == GameManager.GameState.GameOver && gameOverDisplay == null)
            gameOverDisplay = GameOverText();
        else if (gameOverDisplay != null)
            Destroy(gameOverDisplay);
    }

    private GameObject GameOverText()
    {
        GameObject textObj = Instantiate(new GameObject(), transform);
        TextMeshProUGUI text = textObj.AddComponent<TextMeshProUGUI>();
        text.text = "Game Over!";
        text.fontSize = 52f;
        text.fontStyle = FontStyles.Bold;
        text.alignment = TextAlignmentOptions.Center;

        return textObj;
    }
}
