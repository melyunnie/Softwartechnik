using TMPro;
using UnityEngine;

public class AchivementValueTestExample : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int points = 5;
    public TMP_Text pointsText;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        pointsText.text = (points.ToString());
    }
}
