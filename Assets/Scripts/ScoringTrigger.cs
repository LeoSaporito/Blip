using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
public class ScoringTrigger : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoringText;
    [SerializeField] TextMeshProUGUI scoringTextLosingScreen;

    int score;
    void Start()
    {
        score = 0;
    }

    void Update()
    {
        scoringText.text = "Score: " + score;
        scoringTextLosingScreen.text = score.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Scoring Trigger"))
        {
            score += 1;
        }
    }
}
