using TMPro;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] private int point;

    void Start()
    {
        
    }

    // Update is called once per frame
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Score.Instance.UpdateCoin(point);
            Destroy(gameObject);
        }
    }
}
