using UnityEngine;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    public static GameOverUI instance;

    public CanvasGroup panel;
    public TextMeshProUGUI scoreText;

    void Awake()
    {
        instance = this;

        // Sørg for panelet er skjult fra start
        panel.alpha = 0f;
        panel.interactable = false;
        panel.blocksRaycasts = false;
    }

    public void Show(int score)
    {
        panel.alpha = 1f;
        panel.interactable = true;
        panel.blocksRaycasts = true;

        scoreText.alignment = TextAlignmentOptions.Center;
        scoreText.text = "<size=60><b><color=red>GAME OVER</color></b></size>\n";
    }
}
