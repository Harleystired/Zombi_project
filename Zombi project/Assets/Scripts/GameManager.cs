using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverUI;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Zombie"))
        {
            Debug.Log("lose");

            Destroy(other.gameObject);

            GameOver();
        }
    }

    void GameOver()
    {
        Debug.Log("GameOver called");
        Time.timeScale = 0f;
        CoinCollection.coin = 0;
        gameOverUI.SetActive(true);
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
