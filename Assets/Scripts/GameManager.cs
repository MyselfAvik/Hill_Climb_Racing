using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public static GameManager Instance;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private TextMeshProUGUI bestScoreText;
    private bool isGameOver = false;
    void Start()
    {
        bestScoreText.text =PlayerPrefs.GetInt("Best").ToString() + " m";
    }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        Time.timeScale = 1f;



    }
    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                RestartGame();
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }

    public void GameOver()
    {
        isGameOver=true;
        int curScore = GetComponent<Score>().score;
        int bestScore = PlayerPrefs.GetInt("Best");
        if (curScore > bestScore)
        {
            PlayerPrefs.SetInt("Best", curScore);
        }

        gameOver.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
