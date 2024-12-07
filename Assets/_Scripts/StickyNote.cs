using UnityEngine;

public class StickyNote : MonoBehaviour, Interaction
{
    PlayerScript player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameManager.Instance.PlayerScript;
        player.OnPlayerInteraction += DoInteraction;
    }

    public void DoInteraction(Transform noteT)
    {
        if (noteT != transform)
            return;
        OpenStickyNote();
    }

    void OpenStickyNote()
    {
        Debug.Log($"You opened a sticky note!");
    }

    private void OnDestroy()
    {
        player.OnPlayerInteraction -= DoInteraction;
    }
}
