using UnityEngine;
using TMPro;

public class StickyNote : MonoBehaviour, Interaction
{

    [SerializeField][TextArea()] string content;


    PlayerInteractionScript playerInteraction;

    // Start is called before the first frame update
    void Start()
    {
        playerInteraction = GameManager.Instance.Player.GetComponent<PlayerInteractionScript>();
        playerInteraction.OnPlayerInteraction += DoInteraction;
    }

    public void DoInteraction(Transform noteT)
    {
        if (noteT != transform)
            return;
        OpenStickyNote();
    }

    void OpenStickyNote()
    {
        AppManager.Instance.LockCursor(false);
        GameManager.Instance.Player.GetComponent<PlayerMovement>().enabled = false;
        StickyNoteUI.Instance.contentTextField.text = content;
        StickyNoteUI.Instance.StickyNoteGO.SetActive(true);
    }

    private void OnDestroy()
    {
        playerInteraction.OnPlayerInteraction -= DoInteraction;
    }
}
