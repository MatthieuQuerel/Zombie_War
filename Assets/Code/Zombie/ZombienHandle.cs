using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.AI;

public class ZombieHandler : MonoBehaviour
{
    private float lastAttackTime = 0f;
    private float attackCooldown = 2f; 

    // Détecte quand le zombie touche le player
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            var playerScript = other.GetComponent<Player>(); 
            if (playerScript != null)
            {
                // playerScript.toucherParZombie(other);
                playerScript.Degats(1);
            }
        }
    }

    // Détecte quand le zombie reste en contact avec le player
    void OnTriggerStay(Collider other)
    {
        
        if (other.CompareTag("Player") && Time.time >= lastAttackTime + attackCooldown)
        {
            var playerScript = other.GetComponent<Player>(); 
            if (playerScript != null)
            {
                // playerScript.toucherParZombie(other);
                playerScript.Degats(1);
                lastAttackTime = Time.time; 
            }
        }
    }
}