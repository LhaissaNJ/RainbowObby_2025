using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    [Header("Paramètres de Respawn")]
    [SerializeField] private Vector3 lastCheckpointPos;
    [SerializeField] private Minuteur minuteur;
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        lastCheckpointPos = transform.position;
    }

    public void Respawn()
    {
        BougerPerso(lastCheckpointPos);
    }

    private void OnTriggerEnter(Collider other)
    {
        // DEBUG : Affiche le nom de tout ce que tu touches
        Debug.Log("Collision avec : " + other.name + " | Tag : " + other.tag);

        if (other.name == "Téléporteur1")
        {
            minuteur.Debuter();
        }

        if (other.name == "PlateFormeFinale")
        {
            minuteur.Stop();
        }

        if (other.CompareTag("Checkpoint"))
        {
            // ATTENTION : Si le pivot du checkpoint est au sol, 
            // tu seras TP à moitié dans le sol.
            lastCheckpointPos = other.transform.position;
            Debug.Log("Nouveau Checkpoint sauvegardé !");
        }

        // C'EST ICI QUE ÇA BLOQUE PROBABLEMENT
        if (other.CompareTag("Lave") || other.name == "SolLave")
        {
            Debug.Log("MORT : Touché la lave (" + other.name + ")");
            Respawn();
        }
    }

    public void Teleportation(Transform cible)
    {
        if (controller != null)
        {
            controller.enabled = false;
            transform.position = cible.position;
            transform.rotation = cible.rotation;
            Physics.SyncTransforms(); // Force la mise à jour physique
            controller.enabled = true;
        }
    }

    private void BougerPerso(Vector3 targetPosition)
    {
        if (controller != null)
        {
            controller.enabled = false;
            // On ajoute un petit offset vertical (0.5m) pour ne pas être coincé dans le sol
            transform.position = targetPosition + Vector3.up * 0.5f;
            Physics.SyncTransforms();
            controller.enabled = true;
        }
    }
}