using UnityEngine;

public class Player : MonoBehaviour
{
    private static Player Instance;
    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        DontDestroyOnLoad(this);
    }
}
