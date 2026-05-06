using UnityEngine;
using System.Collections;

public class Arme : MonoBehaviour
{
    public float damage = 10f;
    public float timeBetweenShoot = 0.5f;
    public float range = 100f;
    public LayerMask mask;

    public bool FlashArme = false;
    public ParticleSystem flashEffect;
    // public GameObject flashObject;

    public static int kills = 0;
    private float nextTimeShoot = 0f;

    private Camera cam;
    private AudioSource audioSource;

    void Start()
    {
        if (cam == null){
            cam = GetComponentInParent<Camera>();
        }
        if (audioSource == null){
            audioSource = GetComponent<AudioSource>();
        }
        //cam = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= nextTimeShoot)
        {
            StartCoroutine(EffetTir());
            nextTimeShoot = Time.time + timeBetweenShoot;
        }
        }

    void Tirer()
    {

        if (audioSource != null)
        {
            audioSource.PlayOneShot(audioSource.clip);
        }

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
                    UnityEngine.Debug.LogError(kills);
                    kills++;
                    zombie.killZombie();
                }
            }
        }
    }

    IEnumerator EffetTir()
    {
        FlashArme = true;
        
        // Déclencher le Particle System
        if (flashEffect != null)
        {
            flashEffect.Play();
        }
        
        Tirer();
        yield return new WaitForSeconds(0.1f);  // Durée du flash
        
        if (flashEffect != null)
        {
            flashEffect.Stop();
        }
        FlashArme = false;
    }
}
