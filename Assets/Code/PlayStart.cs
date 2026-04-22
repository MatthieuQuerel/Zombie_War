using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayStart : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    

    // Update is called once per frame
   public void StartGame(string nomDeLaScene)
    {
      SceneManager.LoadScene(nomDeLaScene);
    }
}
