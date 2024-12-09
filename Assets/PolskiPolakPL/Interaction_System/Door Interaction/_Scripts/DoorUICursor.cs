using UnityEngine;
using UnityEngine.UI;

public class DoorUICursor : MonoBehaviour
{
    [SerializeField] GameObject defaultCursor;
    [SerializeField] GameObject interactionCursor;
    [SerializeField] GameObject lockedCursor;
    DoorScript doorScript;
    Transform interactableT;

    // Update is called once per frame
    void Update()
    {
        CheckCursorState();
    }

    bool LooksOnDoor()
    {
        if(!GameManager.Instance.PlayerScript.interactiontHitT)
        {
            this.interactableT = null;
            doorScript = null;
            return false;
        }
        this.interactableT = GameManager.Instance.PlayerScript.interactiontHitT;
        if (!interactableT.GetComponent<DoorScript>())
        {
            doorScript=null;
            return false;
        }
        doorScript = interactableT.GetComponent<DoorScript>();
        return true;
    }

    void SwitchTo(GameObject cursor)
    {
        defaultCursor.SetActive(false);
        interactionCursor.SetActive(false);
        lockedCursor.SetActive(false);
        cursor.SetActive(true);
    }

    void CheckCursorState()
    {
        if (!LooksOnDoor())
            SwitchTo(defaultCursor);
        else if (doorScript.Locked)
            SwitchTo(lockedCursor);
        else
            SwitchTo(interactionCursor);
    }
}
