using UnityEngine;
using TMPro;

public class StickyNote : MonoBehaviour, Interaction
{

    [SerializeField] GameObject stickyNoteGO;
    [SerializeField][TextArea()] string content;
    [SerializeField] TMP_Text targetTextField;


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
        targetTextField.text=content;
        stickyNoteGO.SetActive(true);
    }

    private void OnDestroy()
    {
        player.OnPlayerInteraction -= DoInteraction;
    }
}
