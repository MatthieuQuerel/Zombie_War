using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.AI;

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
        if (player != null)
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
            Destroy(gameObject);
            return true;
        }
        return false;
    }
}