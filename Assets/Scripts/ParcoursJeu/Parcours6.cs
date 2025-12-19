using UnityEngine;

public class BalleParcours6 : MonoBehaviour
{
    [Header("Configuration du Spawn")]
    public Transform pointDeSpawn; 

    [Header("Configuration du Puzzle")]
    public GameObject murDisparaitre; // Glisse le mur ici dans l'Inspector

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // --- SYSTÈME DE RESPAWN ---

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Plancher"))
        {
            ReplacerBalle();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Plancher") || other.name == "solLave")
        {
            ReplacerBalle();
        }
    }

    public void ReplacerBalle()
    {
        if (pointDeSpawn != null)
        {
            transform.position = pointDeSpawn.position;

            if (rb != null)
            {
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
        }
    }

    public void BallePoseeSurSocle()
    {
        if (murDisparaitre != null)
        {
            murDisparaitre.SetActive(false); 
        }
    }

    public void BalleRetireeDuSocle()
    {
        if (murDisparaitre != null)
        {
            murDisparaitre.SetActive(true); 
        }
    }
}