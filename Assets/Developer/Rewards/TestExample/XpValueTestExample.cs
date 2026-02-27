using TMPro;
using UnityEngine;

public class XpValueTestExample : MonoBehaviour
{
    public int XP = 5;
    public TMP_Text XPText;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        XPText.text = (XP.ToString());
    }
}
