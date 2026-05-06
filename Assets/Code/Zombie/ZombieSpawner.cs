using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombiePrefab; 
    public float spawnInterval = 4f; 
    public Transform spawnPoint; 
    
    private float nextSpawnTime = 0f;

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnZombie();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    void SpawnZombie()
    {
        if (zombiePrefab != null && spawnPoint != null)
        {
            Instantiate(zombiePrefab, spawnPoint.position, spawnPoint.rotation);
        }
        else
        {
            UnityEngine.Debug.LogError("ERREUR sur : " + gameObject.name + " | Parent : " + transform.parent?.name, gameObject);
        }
    }
}
