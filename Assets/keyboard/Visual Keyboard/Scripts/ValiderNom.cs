using UnityEngine;
using TMPro;

public class ValiderNom : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TMP_InputField entree;
    public TextMeshProUGUI sortie;

    // Update is called once per frame
    public void ecrire()
    {
        sortie.text = entree.text;
    }
}
