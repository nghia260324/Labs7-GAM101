using Firebase.Database;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirebaseDataAccess : MonoBehaviour
{
    public static FirebaseDataAccess Instance;
    DatabaseReference m_Reference;

    public string userKey;
    public string characterKey;


}
