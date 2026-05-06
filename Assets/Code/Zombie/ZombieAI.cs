using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class ZombieAI : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform player;
    private Animator anim; 

    float LifeZombie = 1f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>(); 
        
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null) player = playerObj.transform;
    }

    void Update()
    {
        if (player != null && agent.enabled)
        {
            agent.SetDestination(player.position);
            
            // Récupère la vitesse actuelle du zombie
            float speed = agent.velocity.magnitude; 
            
        }
    }

    public bool killZombie()
    {
        LifeZombie -= 1f;
        if (LifeZombie <= 0f)
        {
            // Stop le mouv
            agent.enabled = false;
            
            // Désactive les colliders pour éviter les interactions
            Collider[] colliders = GetComponents<Collider>();
            foreach (Collider col in colliders)
            {
                col.enabled = false;
            }
            
            anim.SetTrigger("Death");
            
            // Kill zombie après 3s
            StartCoroutine(DestroyAfterAnimation(3f));
            return true;
        }
        return false;
    }

    IEnumerator DestroyAfterAnimation(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}