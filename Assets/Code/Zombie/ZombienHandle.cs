using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class ZombieHandler : MonoBehaviour
{
    private float lastAttackTime = 0f;
    private float attackCooldown = 4f; 

    private Animator anim;
    private bool isAttacking = false; 


    void Start()
    {
        anim = GetComponentInParent<Animator>();
    }

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
    void OnTriggerStay(Collider other)
    {
        
        if (other.CompareTag("Player") && Time.time >= lastAttackTime + attackCooldown && !isAttacking)
        {
            var playerScript = other.GetComponent<Player>(); 
            if (playerScript != null)
            {
                UnityEngine.Debug.Log($"[{gameObject.name}] Lancement attaque!");
                StartCoroutine(AttaqueSynchronisee(playerScript));
                lastAttackTime = Time.time; 
            }
        }
    }

    IEnumerator AttaqueSynchronisee(Player player)
    {
        isAttacking = true;
        UnityEngine.Debug.Log($"[{gameObject.name}] Coroutine d'attaque lancée");
        
        if (anim != null) 
        {
            anim.SetTrigger("Attack");
        }

        yield return new WaitForSeconds(1f); 

        if (player != null) {
            UnityEngine.Debug.Log($"[{gameObject.name}] Application des dégâts");
            player.Degats(1);
        }
        
        isAttacking = false;
    }
}