using UnityEngine;

public class Arme : MonoBehaviour
{
    public float damage = 10f;
    public float timeBetweenShoot = 0.5f;
    public float range = 100f;
    public LayerMask mask;

    private float nextTimeShoot = 0f;

    private Camera cam;

    void Start()
    {
        if (cam == null){
        cam = GetComponentInParent<Camera>();
    }
        //cam = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= nextTimeShoot)
        {
            Tirer();
            nextTimeShoot = Time.time + timeBetweenShoot;
        }
    }

    void Tirer()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction * range, Color.blue, 1f);
       
        if (Physics.Raycast(ray, out hit))
        {
           
            Renderer targetRenderer = hit.transform.GetComponentInChildren<Renderer>();
            if (targetRenderer != null)
            {
                ZombieAI zombie = hit.collider.GetComponent<ZombieAI>();
                if (zombie != null)
                {
                    zombie.killZombie();
                }
            }
        }
    }
}