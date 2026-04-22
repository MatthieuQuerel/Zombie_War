using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombiePrefab; // Le prefab du zombie
    public float spawnInterval = 4f; // Intervalle de spawn en secondes
    public Transform spawnPoint; // Point de spawn
    
    private float nextSpawnTime = 0f;

    void Update()
    {
        // Vérifier si c'est le moment de spawner
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
            UnityEngine.Debug.LogError("Veuillez assigner le prefab du zombie et le spawn point!");
        }
    }
}
