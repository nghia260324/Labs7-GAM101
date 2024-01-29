[System.Serializable]
public class SaveData
{
    public int currentHeart;
    public int currentBullet;
    public int currentArmor;
    public int currentCoin;
    public int currentDistance;
    public int currentTime;
    public int selectedCharacter;

    public SaveData() { }
    public SaveData(int currentHeart, int currentBullet, int currentArmor, int currentCoin, int currentDistance, int currentTime, int selectedCharacter)
    {
        this.currentHeart = currentHeart;
        this.currentBullet = currentBullet;
        this.currentArmor = currentArmor;
        this.currentCoin = currentCoin;
        this.currentDistance = currentDistance;
        this.currentTime = currentTime;
        this.selectedCharacter = selectedCharacter;
    }
}
