using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    private int score;
    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private GameObject gameOverUI;
    private bool isOver = false;

    [SerializeField] private GameObject gameWinUI;
    private bool isWin = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        updateScpore(); 
        gameOverUI.SetActive(false);
        gameWinUI.SetActive(false);
    }
    public void goToMenu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1.0f;  
    }
        public bool isGameWin()
    {
        return isWin;
    }
    public void GameWin()
    {
        isWin = true;
        Time.timeScale = 0;
        gameWinUI.SetActive(true);
    }
    public bool isGameOver()
    {
        return isOver;
    }
    public void restartGame()
    {
        isOver = false;
        score = 0;
        updateScpore();
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Game");
    }

    public void gameOver()
    {
        isOver = true;
        score = 0;
        Time.timeScale = 0;
        gameOverUI.SetActive(true);
    }
    public void addScore(int point)
    {
        if (!isGameOver() && !isWin)
        {
            score += point;
            updateScpore();
        }
    }

    public void updateScpore()
    {
        scoreText.text = score.ToString();
    }

}
