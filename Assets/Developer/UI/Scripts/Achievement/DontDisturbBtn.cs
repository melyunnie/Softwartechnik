using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DontDisturbBtn : AchievementToastNotifications, IClickable
{
    [SerializeField] private Color _ActiveColor;
    [SerializeField] private Color _UnActiveColor;

    private Dictionary<bool, Color> _BtnColor;
    private Button _Btn;

    private void Start()
    {
        _BtnColor = new()
        {
            {true,_ActiveColor},
            {false, _UnActiveColor}
        };

        _Btn = GetComponent<Button>();
        ChangeBtnColor(_BtnColor[_DisturbModeActive]);

        _Btn.onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        _DisturbModeActive = !_DisturbModeActive;
        ChangeBtnColor(_BtnColor[_DisturbModeActive]);
    }

    private void ChangeBtnColor(Color color)
    {
        _Btn.GetComponent<Image>().color = color;
    }
}
