using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private AudioSource finishSFX;
    private bool _isLevelComplete = false;
    void Start()
    {
        finishSFX = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player" && !_isLevelComplete)
        {
            finishSFX.Play();
            Debug.Log("You win!");
            Invoke("CompleteLevel", 2f);
            _isLevelComplete = true;
        }
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
