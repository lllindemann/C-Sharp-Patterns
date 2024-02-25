
using UnityEngine;

/// <summary>
/// Inherit from this base class to create a singleton class which has access on monobehavior functions.
/// e.g. public class ClassName : MonoBehaviourSingleton<ClassName> {}
/// </summary>
public class MonoBehaviourSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static bool monoSingleton_ShuttingDown = false;
    private static object monoSingleton_Lock = new object();
    private static T monoSingleton_Instance;

    /// <summary>
    /// Access singleton instance through this propriety.
    /// </summary>
    public static T GetInstance
    {
        get
        {
            //When instance has already been destroyed return null
            if (monoSingleton_ShuttingDown)
            {
                Debug.LogWarning("[Singleton] Instance of type'" + typeof(T) +
                    "' already destroyed. Returning null.");
                return null;
            }

            lock (monoSingleton_Lock)
            {
                // Check if monoSingleton_Instance is stored
                if (monoSingleton_Instance == null)
                {
                    // Check if instance already exists
                    monoSingleton_Instance = (T)FindObjectOfType(typeof(T));

                    // Create new instance if no instance already exists.
                    if (monoSingleton_Instance == null)
                    {
                        // Create a new GameObject to  which the singleton can be attached
                        var singletonObject = new GameObject();
                        monoSingleton_Instance = singletonObject.AddComponent<T>();
                        singletonObject.name = typeof(T).ToString() + " (Singleton)";

                        // Make instance persistent
                        DontDestroyOnLoad(singletonObject);
                    }
                }

                return monoSingleton_Instance;
            }
        }
    }

    /// <summary>
    /// TRUE while application is shutting down
    /// </summary>
    public void OnApplicationQuit()
    {
        monoSingleton_ShuttingDown = true;
    }

    /// <summary>
    /// TRUE when instance is going to be destroyed
    /// </summary>
    public void OnDestroy()
    {
        monoSingleton_ShuttingDown = true;
    }
   
}

public class MonobehaviorSingletonClassChild : MonoBehaviourSingleton<MonobehaviorSingletonClassChild>
{
    #region PUBLIC_METHODS
    /// <summary>
    /// public logic & behaviour
    /// Call via Singleton.GetInstance.Logic()
    /// </summary> 
    public void Logic()
    {
        // ...
    }
    #endregion
   
}