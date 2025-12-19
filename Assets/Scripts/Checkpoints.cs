using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    [Header("Paramètres de Respawn")]
    public Vector3 lastCheckpointPos;
    public Minuteur minuteur;

    [Header("Apparence et Son")]
    public Material greenMaterial; 

    private CharacterController controller;
    private Rigidbody rb;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        lastCheckpointPos = transform.position; 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("solLave"))
        {
            Debug.Log("Lave touchée ! Respawn...");
            Respawn();
            return;
        }

        if (other.CompareTag("Checkpoint"))
        {
            lastCheckpointPos = other.transform.position;
            Debug.Log("POSITION SAUVEGARDÉE : " + lastCheckpointPos);

            Renderer rend = other.GetComponent<Renderer>();
            if (rend != null && greenMaterial != null)
            {
                rend.material = greenMaterial;
                Debug.Log("Couleur changée en VERT pour " + other.name);
            }

            AudioSource audio = other.GetComponent<AudioSource>();
            if (audio != null) audio.Play();

            if (other.name == "Téléporteur1" && minuteur != null) minuteur.Debuter();
            if (other.name == "PlateFormeFinale" && minuteur != null) minuteur.Stop();
        }
    }

    public void Respawn()
    {
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        DeplacerJoueur(lastCheckpointPos + Vector3.up * 0.5f, transform.rotation);
    }

    private void DeplacerJoueur(Vector3 nouvellePos, Quaternion nouvelleRot)
    {
        if (controller != null && controller.enabled)
        {
            controller.enabled = false; 
            transform.position = nouvellePos;
            transform.rotation = nouvelleRot;
            Physics.SyncTransforms();
            controller.enabled = true;
        }

        else
        {
            transform.position = nouvellePos;
        }
    }
}