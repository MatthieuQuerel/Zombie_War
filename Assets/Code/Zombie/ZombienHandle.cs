using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class ZombieHandler : MonoBehaviour
{
    private float lastAttackTime = 0f;
    private float attackCooldown = 4f; 

    private Animator anim; 


    void Start()
    {
        // Animator du parent zombie
        anim = GetComponentInParent<Animator>();
    }

    // Détecte quand le zombie touche le player
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            var playerScript = other.GetComponent<Player>(); 
            if (playerScript != null)
            {
                // UnityEngine.Debug.Log(playerScript);
                // playerScript.Degats(1);
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
                // UnityEngine.Debug.Log(playerScript);
                // playerScript.toucherParZombie(other);
                StartCoroutine(AttaqueSynchronisee(playerScript));

                if (anim != null)
                {
                    anim.SetTrigger("Attack");
                }
                
                lastAttackTime = Time.time; 
            }
        }
    }


    IEnumerator AttaqueSynchronisee(Player player)
    {
        // 1. On lance l'animation
        anim.SetTrigger("Attack");

        // 2. On attend le temps que le bras se tende (ajuste ce chiffre !)
        yield return new WaitForSeconds(0.9f); 

        // 3. On inflige les dégâts
        if (player != null) {
            player.Degats(1);
        }
    }

}