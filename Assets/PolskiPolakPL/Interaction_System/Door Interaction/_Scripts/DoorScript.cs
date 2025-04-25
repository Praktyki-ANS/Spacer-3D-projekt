using UnityEngine;

public class DoorScript : MonoBehaviour, Interaction
{
    PlayerInteractionScript playerInteraction;
    [SerializeField] Animator doorAnimator;
    [SerializeField] bool isDoorOpened = false;
    Collider doorCollider;
    public bool Locked = false;
    private void Start()
    {
        doorCollider = GetComponent<Collider>();
        playerInteraction = GameManager.Instance.Player.GetComponent<PlayerInteractionScript>();
        playerInteraction.OnPlayerInteraction += DoInteraction;
    }

    public void DoInteraction(Transform doorT)
    {
        if (doorT != transform || Locked)
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
        playerInteraction.OnPlayerInteraction -= DoInteraction;
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
