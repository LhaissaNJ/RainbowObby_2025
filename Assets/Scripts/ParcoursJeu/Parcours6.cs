using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Parcours6 : MonoBehaviour
{
    [Header("UIs et Feedbacks")]
    // public GameObject imageExplication; 

    [Header("Cible et Condition")]
    public string nomDeLaPieceAttendue = "BonnePiece"; 

    [Header("Objets à faire disparaître")]
    public GameObject murDisparaitre; 
    public GameObject socleAFaireDisparaitre; 

    private bool socleCorrect = false;
    private GameObject pieceRef;


    public void OnSocleSelect(SelectEnterEventArgs args)
    {
        if (args.interactableObject.transform.name.Contains(nomDeLaPieceAttendue))
        {
            socleCorrect = true;
            pieceRef = args.interactableObject.transform.gameObject;
            
            VerifierPuzzle();
        }
    }

    public void OnSocleExit(SelectExitEventArgs args) 
    { 
        if (args.interactableObject.transform.name.Contains(nomDeLaPieceAttendue))
        {
            socleCorrect = false; 
            pieceRef = null;
        }
    }

    private void VerifierPuzzle()
    {
        if (socleCorrect)
        {
            if (murDisparaitre != null) murDisparaitre.SetActive(false);
            if (pieceRef != null) pieceRef.SetActive(false);
            if (socleAFaireDisparaitre != null) socleAFaireDisparaitre.SetActive(false);
        }
    }
}