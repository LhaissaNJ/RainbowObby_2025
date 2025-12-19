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
        Debug.Log("Script Checkpoint initialisé sur : " + gameObject.name);
    }

    private void OnTriggerEnter(Collider other)
    {
        // DEBUG : Affiche TOUT ce que la balle touche
        Debug.Log("Collision détectée avec : " + other.name + " | Tag : " + other.tag);

        // 1. DETECTION DE LA LAVE
        if (other.CompareTag("solLave"))
        {
            Debug.Log("Lave touchée ! Respawn...");
            Respawn();
            return;
        }

        // 2. DETECTION DES CHECKPOINTS
        if (other.CompareTag("Checkpoint"))
        {
            // On sauvegarde la position
            lastCheckpointPos = other.transform.position;
            Debug.Log("POSITION SAUVEGARDÉE : " + lastCheckpointPos);

            // Changement de couleur
            Renderer rend = other.GetComponent<Renderer>();
            if (rend != null && greenMaterial != null)
            {
                rend.material = greenMaterial;
                Debug.Log("Couleur changée en VERT pour " + other.name);
            }

            // Son
            AudioSource audio = other.GetComponent<AudioSource>();
            if (audio != null) audio.Play();

            // Gestion du minuteur
            if (other.name == "Téléporteur1" && minuteur != null) minuteur.Debuter();
            if (other.name == "PlateFormeFinale" && minuteur != null) minuteur.Stop();
        }
    }

    public void Respawn()
    {
        // On réinitialise la physique avant le déplacement
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        // Téléportation avec un petit décalage Y pour ne pas être coincé dans le sol
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