using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayStart : MonoBehaviour
{
      public void StartGame(string nomDeLaScene)
    {
      SceneManager.LoadScene(nomDeLaScene);
    }
}
