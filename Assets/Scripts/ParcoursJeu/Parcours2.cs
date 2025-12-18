using UnityEngine;

public class Parcours2 : MonoBehaviour
{
    // Ce script gère la balle qui, en touchant la cible, 
    // téléporte le joueur ET active la boule.
    
    [Header("Références")]
    public Checkpoints joueurCheckpoints;   
    public Transform destination; 
    
    [Header("Objets à Activer")]
    public GameObject bouleApparaitre; // Référence vers l'objet "BouleApparaitre"

    private void OnCollisionEnter(Collision collision)
    {
        // Vérifie si l'objet qui touche la cible a le tag "Balle"
        if (collision.gameObject.CompareTag("Balle"))
        {
            // 1. Gérer la téléportation
            if (joueurCheckpoints != null && destination != null)
            {
                joueurCheckpoints.Teleportation(destination);
            }

            // 2. Activer l'objet "BouleApparaitre"
            if (bouleApparaitre != null)
            {
                bouleApparaitre.SetActive(true);
            }
            else
            {
                Debug.LogWarning("Attention : L'objet 'BouleApparaitre' n'est pas assigné dans l'inspecteur de " + gameObject.name);
            }
        }
    }
}