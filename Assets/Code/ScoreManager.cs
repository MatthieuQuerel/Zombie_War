using UnityEngine;
using TMPro;


public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; 
    public Player scriptJoueur; 

    void Update()
    {
      
        scoreText.text = "Nombre de kills : " + Arme.kills + 
                         "\nNombre de Vies : " + scriptJoueur.lifePlayer;
    }
}