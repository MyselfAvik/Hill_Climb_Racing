using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private AudioClip gameOverSound;
    [SerializeField] private AudioSource gameOverSoundSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            gameOverSoundSource.PlayOneShot(gameOverSound);
            GameManager.Instance.GameOver();
        }
    }
   
 
}
