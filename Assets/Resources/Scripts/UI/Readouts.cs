using UnityEngine;
using UnityEngine.UI;

public class Readouts : MonoBehaviour
{

    public Text ScoreText;

    public Text CurrencyText;

    private void Update()
    {
        ScoreText.text = "Score: " + Score.GetScoreString();
    }
}
