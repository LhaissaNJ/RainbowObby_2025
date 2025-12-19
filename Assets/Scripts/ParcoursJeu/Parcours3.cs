using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Parcours3 : MonoBehaviour
{
    [Header("UIs et Feedbacks")]
    public GameObject imageExplication; 
    public GameObject bonneRep1; 
    public GameObject bonneRep2; 
    public GameObject bonneRep3; 

    [Header("Objets à faire disparaître")]
    public GameObject murDisparaitre; 
    public GameObject[] soclesAFaireDisparaitre; 

    private bool socle1Correct = false;
    private bool socle2Correct = false;
    private bool socle3Correct = false;

    private GameObject piece1Ref;
    private GameObject piece2Ref;
    private GameObject piece3Ref;

    void Start()
    {
        if (imageExplication != null) imageExplication.SetActive(true);
        if (bonneRep1 != null) bonneRep1.SetActive(false);
        if (bonneRep2 != null) bonneRep2.SetActive(false);
        if (bonneRep3 != null) bonneRep3.SetActive(false);
    }

    public void OnSocle1Select(SelectEnterEventArgs args)
    {
        if (args.interactableObject.transform.name.Contains("Piece1"))
        {
            socle1Correct = true;
            piece1Ref = args.interactableObject.transform.gameObject;
            MettreAJourAffichage();
            VerifierPuzzle();
        }
    }

    public void OnSocle1Exit(SelectExitEventArgs args) 
    { 
        if (args.interactableObject.transform.name.Contains("Piece1"))
        {
            socle1Correct = false; 
            piece1Ref = null;
            MettreAJourAffichage();
        }
    }

    public void OnSocle2Select(SelectEnterEventArgs args)
    {
        if (args.interactableObject.transform.name.Contains("Piece2"))
        {
            socle2Correct = true;
            piece2Ref = args.interactableObject.transform.gameObject;
            MettreAJourAffichage();
            VerifierPuzzle();
        }
    }

    public void OnSocle2Exit(SelectExitEventArgs args) 
    { 
        if (args.interactableObject.transform.name.Contains("Piece2"))
        {
            socle2Correct = false; 
            piece2Ref = null;
            MettreAJourAffichage();
        }
    }

    public void OnSocle3Select(SelectEnterEventArgs args)
    {
        if (args.interactableObject.transform.name.Contains("Piece3"))
        {
            socle3Correct = true;
            piece3Ref = args.interactableObject.transform.gameObject;
            MettreAJourAffichage();
            VerifierPuzzle();
        }
    }

    public void OnSocle3Exit(SelectExitEventArgs args) 
    { 
        if (args.interactableObject.transform.name.Contains("Piece3"))
        {
            socle3Correct = false; 
            piece3Ref = null;
            MettreAJourAffichage();
        }
    }

    private void MettreAJourAffichage()
    {
        if (bonneRep1 != null) bonneRep1.SetActive(socle1Correct);
        if (bonneRep2 != null) bonneRep2.SetActive(socle2Correct);
        if (bonneRep3 != null) bonneRep3.SetActive(socle3Correct);

        bool unePieceEstCorrecte = socle1Correct || socle2Correct || socle3Correct;
        
        if (imageExplication != null)
        {
            imageExplication.SetActive(!unePieceEstCorrecte);
        }
    }

    private void VerifierPuzzle()
    {
        if (socle1Correct && socle2Correct && socle3Correct)
        {
            if (murDisparaitre != null) murDisparaitre.SetActive(false);

            if (piece1Ref != null) piece1Ref.SetActive(false);
            if (piece2Ref != null) piece2Ref.SetActive(false);
            if (piece3Ref != null) piece3Ref.SetActive(false);

            foreach (GameObject socle in soclesAFaireDisparaitre)
            {
                if (socle != null) socle.SetActive(false);
            }

            if (imageExplication != null) imageExplication.SetActive(false);
            if (bonneRep1 != null) bonneRep1.SetActive(false);
            if (bonneRep2 != null) bonneRep2.SetActive(false);
            if (bonneRep3 != null) bonneRep3.SetActive(false);
        }
    }
}