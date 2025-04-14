using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    private GameManager gameManager;
    private AudioManager audioManager;

    private void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager>()  ;
        audioManager = FindAnyObjectByType<AudioManager>() ;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin")){
            gameManager.addScore(10);
            audioManager.playCoinSound();
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("Trap"))
        {
            
            gameManager.gameOver();
        }
        else if (collision.CompareTag("Enemy"))
        {
            gameManager.gameOver();
        }
        else if (collision.CompareTag("Key"))
        {
            Destroy(collision.gameObject);
            gameManager.GameWin();
        }
    }
}
