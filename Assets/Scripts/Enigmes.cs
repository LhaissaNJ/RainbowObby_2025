using UnityEngine;

public class Enigmes : MonoBehaviour
{
    public string bonneReponse; 
    public GameObject murAssocie;
    public GameObject clavierAssocie;

    void Start()
    {
        if (clavierAssocie != null) clavierAssocie.SetActive(false);
    }

    public void OnSelect()
    {
        if (clavierAssocie != null)
        {
            clavierAssocie.SetActive(true);
        }
    }
}