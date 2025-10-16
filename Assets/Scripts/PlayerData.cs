using UnityEngine;
using Firebase.Firestore;

[FirestoreData]
public class PlayerData
{
    [FirestoreProperty]
    public int coins { get; set; }

    [FirestoreProperty]
    public int level { get; set; }
}
