using UnityEngine;
using TMPro;

public class StickyNote : MonoBehaviour, Interaction
{

    [SerializeField][TextArea()] string content;


    PlayerInteractionScript player;

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
        GameManager.Instance.PlayerScript.gameObject.GetComponent<PlayerMovement>().enabled = false;
        AppManager.Instance.LockCursor(false);
        StickyNoteUI.Instance.contentTextField.text = content;
        StickyNoteUI.Instance.StickyNoteGO.SetActive(true);
    }

    private void OnDestroy()
    {
        player.OnPlayerInteraction -= DoInteraction;
    }
}
