using System.Collections.Generic;

[System.Serializable]
public class Character
{
    public string id;
    public int gem;
    public SaveData saveData;
    public int[] unlockedCharacters;
    public List<Record> records;

    public Character() { }

    public Character(string id, int gem,SaveData saveData, int[] unlockedCharacters,List<Record> records)
    {
        this.id = id;
        this.gem = gem;
        this.saveData = saveData;
        this.unlockedCharacters = unlockedCharacters;
        this.records = records;
    }
}
