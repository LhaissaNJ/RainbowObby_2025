// using UnityEngine;
// using UnityEngine.XR.Interaction.Toolkit;

// public class Parcours3 : MonoBehaviour
// {
//     [Header("UIs et Feedbacks")]
//     public GameObject imageExplication; 

//     [Header("Objets à faire disparaître")]
//     public GameObject murDisparaitre; 
//     public GameObject[] soclesAFaireDisparaitre; 

//     private bool socleCorrect = false;


//     void Start()
//     {

//     }

//     public void OnSocle1Select(SelectEnterEventArgs args)
//     {
//         if (args.interactableObject.transform.name.Contains("Piece1"))
//         {
//             socle1Correct = true;
//             piece1Ref = args.interactableObject.transform.gameObject;
//             MettreAJourAffichage();
//             VerifierPuzzle();
//         }
//     }

//     public void OnSocle1Exit(SelectExitEventArgs args) 
//     { 
//         if (args.interactableObject.transform.name.Contains("Piece1"))
//         {
//             socle1Correct = false; 
//             piece1Ref = null;
//             MettreAJourAffichage();
//         }
//     }
// }