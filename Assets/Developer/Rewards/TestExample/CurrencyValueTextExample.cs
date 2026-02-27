using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyValueTextExample : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int Currency = 5;
    public TMP_Text CurrencyText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CurrencyText.text = (Currency.ToString());
    }
}
