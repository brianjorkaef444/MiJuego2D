using UnityEngine;
using Firebase.Firestore;
using System.Threading.Tasks;

public class DatabaseManager : MonoBehaviour
{
    FirebaseFirestore db;

    void Start()
    {
        db = FirebaseFirestore.DefaultInstance;
    }

    // 🔹 Guardar progreso del jugador
    public async void SavePlayerData(int coins, int level)
    {
        PlayerData data = new PlayerData { coins = coins, level = level };

        DocumentReference docRef = db.Collection("players").Document("player1");
        await docRef.SetAsync(data);
        Debug.Log("✅ Datos del jugador guardados en Firestore");
    }

    // 🔹 Leer progreso del jugador
    public async void LoadPlayerData()
    {
        DocumentReference docRef = db.Collection("players").Document("player1");
        DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();

        if (snapshot.Exists)
        {
            PlayerData data = snapshot.ConvertTo<PlayerData>();
            Debug.Log($"💰 Monedas: {data.coins}, Nivel: {data.level}");
        }
        else
        {
            Debug.Log("⚠️ No hay datos guardados para este jugador.");
        }
    }
}
