using UnityEngine;
using Firebase;
using Firebase.Firestore;

public class FirebaseInit : MonoBehaviour
{
    void Start()
    {
        // Inicializar Firebase
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            var dependencyStatus = task.Result;
            if (dependencyStatus == DependencyStatus.Available)
            {
                Debug.Log("✅ Firebase inicializado correctamente");
                FirebaseFirestore db = FirebaseFirestore.DefaultInstance;
            }
            else
            {
                Debug.LogError($"❌ Error al inicializar Firebase: {dependencyStatus}");
            }
        });
    }
}
