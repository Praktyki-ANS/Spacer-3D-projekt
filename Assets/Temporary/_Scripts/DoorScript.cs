using UnityEngine;

public class DoorScript : MonoBehaviour, Interaction
{
    PlayerScript playerScript;
    [SerializeField] Animator doorAnimator;
    [SerializeField] bool isDoorOpened = false;
    Collider doorCollider;
    private void Start()
    {
        doorCollider = GetComponent<Collider>();
        playerScript = GameManager.Instance.PlayerScript;
        playerScript.OnPlayerInteraction += DoInteraction;
    }

    public void DoInteraction(Transform doorT)
    {
        if (doorT != transform)
            return;
        if (isDoorOpened)
            CloseDoor();
        else
            OpenDoor();

    }

    void OpenDoor()
    {
        doorAnimator.Play("OpenDoorAnimation");
        isDoorOpened = true;
    }

    void CloseDoor()
    {
        doorAnimator.Play("CloseDoorAnimation");
        isDoorOpened = false;
    }

    private void OnDestroy()
    {
        playerScript.OnPlayerInteraction -= DoInteraction;
    }
    void EnableCollider()
    {
        doorCollider.enabled = true;
    }
    void DisableCollider()
    {
        doorCollider.enabled = false;
    }
}
