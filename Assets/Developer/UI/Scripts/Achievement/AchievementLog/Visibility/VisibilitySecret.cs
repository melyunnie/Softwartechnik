
public class VisibilitySecret : VisibilityController
{
    public override void SetVisibility(AchievementSlot achievementSlot, AchievementsSO achievementSO)
    {
        achievementSlot.achievementImage.color = achievementSO.visibility.achievementSecretColor;
        achievementSlot.achievementImage.sprite = achievementSO.achievementSprite;
        achievementSlot.achievementDescriptionImage.color = achievementSO.visibility.achievementSecretColor;
        achievementSlot.achievementDescriptionImage.sprite = achievementSlot.achievementImage.sprite;
        achievementSlot.achievementDescriptionName.text = achievementSO.visibility.achievementSecretName;
        achievementSlot.achievementDescriptionReward.text = achievementSO.visibility.achievementSecretReward;
    }
}
