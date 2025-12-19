using UnityEngine;

public class BalleParcours2 : MonoBehaviour
{
    [Header("Configuration")]
    public GameObject cible;
    public GameObject cibleMur;
    public GameObject boulesApparaitre;
    public Transform pointDeSpawn; 

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("solLave"))
        {
            ReapparaitreAuDepart();
        }
        
        if (other.CompareTag("Cible")) 
        {
            GagnerPartie();
        }
    }

    public void ReapparaitreAuDepart()
    {
        Debug.Log("La balle est tombée ! Réapparition au point de spawn.");

        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.Sleep(); 
        }

        if (pointDeSpawn != null)
        {
            transform.position = pointDeSpawn.position;
            transform.rotation = pointDeSpawn.rotation;
        }
        else 
        {
            Debug.LogError("Attention : Aucun 'Point De Spawn' n'a été glissé dans l'inspecteur !");
        }
    }

    public void GagnerPartie()
    {
        Debug.Log("VICTOIRE : La cible est touchée !");
        if (cible != null) cible.SetActive(false);
        if (cibleMur != null) cibleMur.SetActive(false);
        if (boulesApparaitre != null) boulesApparaitre.SetActive(true);
    }
}