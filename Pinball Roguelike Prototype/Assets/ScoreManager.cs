using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ScoreManager : MonoBehaviour
{

    public static ScoreManager Instance;

    private void Awake()
    {
        Instance = this;
    }
    public int points;
    public int scoringTarget;

    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI scoringTargetText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (points > scoringTarget)
        {
            GameManager.Instance.WinRound();
        }
    }

    public void IncreaseScore(int pointsToAdd)
    {
        points += pointsToAdd;
        pointsText.SetText(points.ToString());
    }
}
