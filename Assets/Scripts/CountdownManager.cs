using System.Collections;
using UnityEngine;
using TMPro;

public class CountdownManager : MonoBehaviour
{
    public TextMeshProUGUI countdownText;
    public GameObject player; // valgfri hvis du vil deaktivere player under countdown

    void Start()
    {
        StartCoroutine(Countdown());
    }

    IEnumerator Countdown()
    {
        if (player != null)
            player.SetActive(false); // Deaktiver spiller

        countdownText.gameObject.SetActive(true);

        countdownText.text = "3";
        yield return new WaitForSeconds(1f);

        countdownText.text = "2";
        yield return new WaitForSeconds(1f);

        countdownText.text = "1";
        yield return new WaitForSeconds(1f);

        countdownText.text = "GO";
        yield return new WaitForSeconds(0.5f);

        countdownText.gameObject.SetActive(false);

        if (player != null)
            player.SetActive(true); // Aktiver spiller
    }
}
