using UnityEngine;
using TMPro;

public class UpdateSore : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    void Start()
    {
        scoreText.text = "Score: " + PublicVars.score;
        PublicVars.score = 0;
    }

}
