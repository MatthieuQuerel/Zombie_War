using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    public float lifePlayer = 3;
    
    public GameObject GameOver; 

    public GameObject tabScore; 
    private bool isVisible = false;

    void Start()
    {
        tabScore.SetActive(false);
    }

    void Update()
    {    
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleTabScore();
        }
    }

    // private void OnTriggerEnter(Collider other)
    // { 
    //     // Vérifie si c'est un zombie qui touche le joueur
    //     ZombieAI zombie = other.GetComponentInParent<ZombieAI>();
    //     // UnityEngine.Debug.Log("Le joueur a pas été touché !");
        
    //     // // UnityEngine.Debug.Log(zombie);
    //     if (zombie != null)
    //     {
    //         // UnityEngine.Debug.Log("Le joueur a été touché par un zombie !");
    //         Degats(1);
    //     }
    // }

    public void Degats(int points)
    {
        lifePlayer -= points;
        UnityEngine.Debug.Log($"Dégâts reçus: {points} | Vie restante: {lifePlayer}");

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

    void ToggleTabScore()
    {
        isVisible = !isVisible; 
        tabScore.SetActive(isVisible);
    }
}
