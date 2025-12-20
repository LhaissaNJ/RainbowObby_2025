using UnityEngine;

public class Enigmes : MonoBehaviour
{
    public string bonneReponse; // "A", "B", "C", "D"
    public GameObject murAssocie;

    public void OnSelect()
    {
        ClavierManager.instance.OuvrirClavier(this);
    }
}
