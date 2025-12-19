using UnityEngine;

public class ClavierManager : MonoBehaviour
{
    public static ClavierManager instance;

    private Enigmes enigmeActive;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip sonMauvaiseReponse;

    void Awake()
    {
        instance = this;
        gameObject.SetActive(false);
    }

    public void OuvrirClavier(Enigmes enigme)
    {
        enigmeActive = enigme;
        gameObject.SetActive(true);
    }

    public void BoutonAppuye(string lettre)
    {
        if (lettre == enigmeActive.bonneReponse)
        {
            enigmeActive.gameObject.SetActive(false);
            enigmeActive.murAssocie.SetActive(false);
            FermerClavier();
        }
        else
        {
            audioSource.PlayOneShot(sonMauvaiseReponse);
        }
    }

    void FermerClavier()
    {
        enigmeActive = null;
        gameObject.SetActive(false);
    }
}
