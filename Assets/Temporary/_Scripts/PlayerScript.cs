using System;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] Transform cameraT;
    [SerializeField] float playerReach = 1;
    [SerializeField] LayerMask interactionLayer;
    public event Action<Transform> OnPlayerInteraction;
    RaycastHit hit;
    Ray ray;
    public Transform interactiontHitT {  get; private set; }

    private void Start()
    {
        if (!cameraT)
        {
            cameraT = transform.GetChild(0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        ray = new Ray(cameraT.position, cameraT.forward);
        Debug.DrawRay(cameraT.position, cameraT.forward * playerReach,Color.blue);
        if (!Physics.Raycast(ray, out hit, playerReach, interactionLayer))
        {
            interactiontHitT = null;
            return;
        }
        interactiontHitT = hit.transform;
        Debug.DrawRay(cameraT.position, cameraT.forward * playerReach, Color.green);
        if (Input.GetMouseButtonDown(0))
        {
            Debug.DrawRay(cameraT.position, cameraT.forward * playerReach, Color.red,0.1f);
            OnPlayerInteraction?.Invoke(hit.transform);
            Debug.Log($"Interacted with {hit.collider.name}");
        }
    }
}
