using Firebase.Database;
using Firebase.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class CharacterDao : MonoBehaviour
{
    public static CharacterDao instance;
    public Character character;

    private DatabaseReference m_Reference;

    private void Awake() {
        m_Reference = FirebaseDatabase.DefaultInstance.RootReference;
        instance = this;
    }

    private void Start()
    {
        //WriteNewCharacter("766f76e1-5116-4f64-86c9-07e64adee465", 0);
        character = GetCharacter("766f76e1-5116-4f64-86c9-07e64adee465");
    }

    private Character GetCharacter(string characterId)
    {
        Character character = null;
        m_Reference.Child("CHARACTER").Child(characterId).GetValueAsync().ContinueWithOnMainThread(task => {
            if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                if (snapshot.Exists)
                {
                    character = JsonUtility.FromJson<Character>(snapshot.GetRawJsonValue());
                    Debug.Log(JsonUtility.ToJson(character));
                }
                else
                {
                    Debug.LogError("Character data not found.");
                }
            }
            else
            {
                Debug.LogError("Failed to retrieve character data: " + task.Exception);
            }
        });
        return character;
    }
    public void WriteNewCharacter(string id, int gem)
    {
        SaveData saveData = new SaveData(3, 4, 15, 0, 0, 0, 0);
        int[] unlockedCharacters = {0};
        List<Record> records = new List<Record>();
        Character newCharacter = new Character(id, gem, saveData, unlockedCharacters,records);
        string jsonCharacter = JsonUtility.ToJson(newCharacter);

        Debug.Log("Json Character: " + jsonCharacter);

        m_Reference.Child("CHARACTER").Child(id).SetRawJsonValueAsync(jsonCharacter).ContinueWithOnMainThread(task =>
        {
            if (task.IsCompleted)
            {
                Debug.Log("Character data written to Firebase.");
            }
            else
            {
                Debug.LogError("Failed to write character data to Firebase: " + task.Exception);
            }
        });
    }
}
