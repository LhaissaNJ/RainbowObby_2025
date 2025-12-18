using UnityEngine;
using TMPro; // Nécessaire pour TextMeshPro

public class Minuteur : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Glisse ton texte UI ici
    private float debut;
    private bool isRunning = false;

    void Update()
    {
        if (isRunning)
        {
            float t = Time.time - debut;
            string minutes = ((int)t / 60).ToString("00");
            string secondes = (t % 60).ToString("00");
            string millisecondes = ((int)(t * 100f) % 100).ToString("00");

            timerText.text = minutes + ":" + secondes + ":" + millisecondes;
        }
    }

    public void Debuter()
    {
        if (!isRunning)
        {
            debut = Time.time;
            isRunning = true;
        }
    }

    public void Stop()
    {
        isRunning = false;
    }
}