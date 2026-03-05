using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
using static VisibilityEntry;

public class AchievementSlot : AchievementLogController, IPointerClickHandler, IClickable
{
    [Header("----Achievement Components----")]
    [HideInInspector] public AchievementsSO achievementSO;

    [Header("----Achievement Dicctionaries----")]
    private Dictionary<status, bool> _AchievementCompleted;
    private Dictionary<visibility, IVisibility> _AchievementVisibility;

    [Header("----Achievement Data----")]
    public string achievementName;
    public Sprite achievementSprite;
    public visibility achievementVisibility;
    public status _AchievementStatus;
    private CategoryEntry _AchievementCategory;
    [HideInInspector] public VisibilityEntry visibilityEntry;
    public int _AchievementID;

    [Header("----Achievement Slot----")]
    public Image achievementImage;
    [SerializeField] private GameObject _SelectShader;
    [SerializeField] private Image _BorderRarity;
    [SerializeField] private GameObject _StatusGameObject;
    [SerializeField] private GameObject _StatusText;


    private void Start()
    {
        _AchievementCompleted = new() 
        { 
            { status.Completed, true}, 
            { status.Blocked, false} 
        };

        _AchievementVisibility = new()
        {
            {visibility.Public, new VisibilityPublic()},
            {visibility.Hidden, new VisibilityHidden()},
            {visibility.Secret, new VisibilitySecret()}
        };

        SetRarity();
        SetVisibility();
        CheckAchievementStatus(achievementSO);
    }

    public void AddDataToAchievement(AchievementsSO achievementSO)
    {
        this.achievementName = achievementSO.achievementName;
        this.achievementSprite = achievementSO.achievementSprite;
        this.achievementVisibility = achievementSO.visibility.achievementVisibility;
        this._AchievementStatus = achievementSO.achievementStatus;

        achievementImage.sprite = achievementSprite;
        _AchievementID = achievementSO.GetInstanceID();
        this.achievementSO = Instantiate(achievementSO);
    }

    public void AddDescriptionComponents(Image achievementDescriptionImage, TMP_Text achievementDescriptionName, TMP_Text achievementDescriptionCriterias,Slider achievementDescriptionProgressBar, TMP_Text achievementDescriptionProgress, TMP_Text achievementDescriptionReward, List<AchievementSlot> achievementSlotList)
    {
        this.achievementDescriptionImage = achievementDescriptionImage;
        this.achievementDescriptionName = achievementDescriptionName;
        _AchievementDescriptionCriterias = achievementDescriptionCriterias;
        _AchievementDescriptionProgressBar = achievementDescriptionProgressBar;
        _AchievementDescriptionProgress = achievementDescriptionProgress;
        this.achievementDescriptionReward = achievementDescriptionReward;
        _AchievementSlotList = achievementSlotList;
    }

    public void OnPointerClick(PointerEventData eventData) => OnClick();

    public void DeselectAchievementUI()
    {
        foreach (AchievementSlot item in _AchievementSlotList)
        {
            item._SelectShader.SetActive(false);
        }
    }

    public void OnClick()
    {
        DeselectAchievementUI();

        _SelectShader.SetActive(true);

        achievementDescriptionImage.sprite = achievementSprite;
        _AchievementDescriptionCriterias.text = achievementSO.achievementDescriptionCriterias;
        _AchievementDescriptionProgressBar.value = 0;
        _AchievementDescriptionProgress.text = "0/10";

        if (achievementVisibility == visibility.Secret)
        {
            SetVisibility();
            return;
        }

        achievementDescriptionImage.color = Color.white;
        achievementDescriptionName.text = achievementName;
        achievementDescriptionReward.text = achievementSO.reward;

        Debug.Log("Achievement Clicked");
    }

    private void SetRarity()
    {
        _BorderRarity.color = achievementSO.rarity.rarityColor;
    }

    private void SetVisibility()
    {
        _AchievementVisibility[achievementVisibility].SetVisibility(GetComponent<AchievementSlot>(), achievementSO);
    }

    private void SetStatus(bool status) 
    {
        achievementImage.gameObject.SetActive(status);
        _StatusText.SetActive(status);
        
        if(achievementVisibility != visibility.Secret)
            _StatusGameObject.SetActive(!status);

        if(status)
            achievementDescriptionReward.text = $"<s>{achievementSO.reward}<s>";
    }

    public void CheckAchievementStatus(AchievementsSO achievementSO)
    {
        SetStatus(_AchievementCompleted[achievementSO.achievementStatus]);
    }

}
