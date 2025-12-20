using UnityEngine;

public class BoutonEnigme : MonoBehaviour
{
    [Header("Configuration")]
    public string maLettre; 
    public string bonneReponse; 
    
    [Header("Objets à faire disparaître")]
    public GameObject parentEnigme; 

    public void ValiderReponse()
    {
        if (maLettre == bonneReponse)
        {
            Debug.Log("Bonne réponse ! Enigme résolue.");
            if (parentEnigme != null)
            {
                parentEnigme.SetActive(false);
            }
        }
        else
        {
            Debug.Log("Mauvaise réponse...");
        }
    }
}