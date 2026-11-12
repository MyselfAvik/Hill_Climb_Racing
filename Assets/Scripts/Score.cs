using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public static Score Instance;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI coinScore;
    [SerializeField] private Transform playerPos;
    private Vector2 distance;
    private Vector2 startPos;
    public int score;
    public int coin;
    void Start()
    {
        coin = 0;
        startPos = playerPos.position;
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    // Update is called once per frame
    void Update()
    {
        distance = (Vector2)playerPos.position - startPos;
        distance.y = 0f;
        if(distance.x < 0f) distance.x = 0f;

        score =Mathf.FloorToInt(distance.x);
        scoreText.text = score.ToString()+ " m" ;
    }

    public void UpdateCoin(int point)
    {
        coin+= point;
        coinScore.text = coin.ToString();
    }
}
