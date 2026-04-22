using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    public float lifePlayer = 3;
    
    public GameObject GameOver; 

    // void Update()
    // {    
    //     if (Input.GetKeyDown(KeyCode.Space))
    //     {
    //         Degats(1); 
    //     }
    // }

    private void OnTriggerEnter(Collider other)
    { 
        if (other.CompareTag("Zombie"))
        {
            Degats(1);
        }
    }

    void Degats(int points)
    {
        lifePlayer -= points;

        if (lifePlayer <= 0)
        {
            Game_Over();
        }
    }

    void Game_Over()
    {
        GameOver.SetActive(true);
        Time.timeScale = 0f;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

    }
    
    public void RestartGame()
    {
        Time.timeScale = 1f;

        string currentSceneName = SceneManager.GetActiveScene().name;

        SceneManager.LoadScene(currentSceneName);
    }
}
