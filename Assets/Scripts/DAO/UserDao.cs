using Firebase.Database;
using Firebase.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class UserDao : MonoBehaviour
{
    public static UserDao instance;
    public User user;
    
    private DatabaseReference m_Reference;


    private void Awake()
    {
        m_Reference = FirebaseDatabase.DefaultInstance.RootReference;
        instance = this;
    }

    private void Start()
    {
        //WriteNewUser(Guid.NewGuid().ToString(), "nghia260324@gmail.com", "123456789", "Nghia", Guid.NewGuid().ToString(), 0, Guid.NewGuid().ToString());
        user = GetUser("f51ec746-270e-42e7-bc2f-69f6a309b01d");
    }

    private User GetUser(string key)
    {
        User user = null;
        m_Reference.Child("USER").Child(key).GetValueAsync().ContinueWithOnMainThread(task => {
            if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                if (snapshot.Exists)
                {
                    user = JsonUtility.FromJson<User>(snapshot.GetRawJsonValue());
                    Debug.Log(JsonUtility.ToJson(user));
                }
                else
                {
                    Debug.LogError("User data not found.");
                }
            }
            else
            {
                Debug.LogError("Failed to retrieve user data: " + task.Exception);
            }
        });
        return user;
    }
    public void WriteNewUser(string id, string email, string password, string name, string idAvatar, int status, string idCharacter)
    {
        User user = new User(id, email, password, name, idAvatar, status, idCharacter);
        string json = JsonUtility.ToJson(user);

        m_Reference.Child("USER").Child(id).SetRawJsonValueAsync(json);
    }
}
