using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private void Awake()
    {
        if (Instance && Instance != this)
            Destroy(this);
        else
            Instance = this;
    }
    public PlayerInteractionScript PlayerScript;
}
