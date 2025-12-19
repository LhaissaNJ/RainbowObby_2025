using UnityEngine;

public class Parcours8 : MonoBehaviour
{
    [Header("Configuration des Boutons")]
    public GameObject visuelBouton1;
    public GameObject afficheBouton1; 
    public GameObject visuelBouton2;
    public GameObject afficheBouton2; 

    [Header("Configuration Fin")]
    public GameObject objetFin;

    [Header("Paramètres Visuels")]
    public Material greenMaterial; 

    private bool bouton1Active = false;
    private bool bouton2Active = false;

    void Start()
    {
        if (objetFin != null) objetFin.SetActive(false);
        if (afficheBouton1 != null) afficheBouton1.SetActive(false);
        if (afficheBouton2 != null) afficheBouton2.SetActive(false);
    }

    public void ActiverBouton1()
    {
        if (!bouton1Active)
        {
            bouton1Active = true;
            if (afficheBouton1 != null) afficheBouton1.SetActive(true);
            ChangerCouleur(visuelBouton1);
            VerifierConditions();
        }
    }

    public void ActiverBouton2()
    {
        if (!bouton2Active)
        {
            bouton2Active = true;
            if (afficheBouton2 != null) afficheBouton2.SetActive(true);
            ChangerCouleur(visuelBouton2);
            VerifierConditions();
        }
    }

    private void ChangerCouleur(GameObject bouton)
    {
        if (bouton != null && greenMaterial != null)
        {
            Renderer rend = bouton.GetComponent<Renderer>();
            if (rend != null)
            {
                rend.material = greenMaterial;
            }
        }
    }

    private void VerifierConditions()
    {
        if (bouton1Active && bouton2Active)
        {
            if (objetFin != null)
            {
                objetFin.SetActive(true);
                Debug.Log("Tous les boutons sont activés !");
            }
        }
    }
}