using UnityEngine;

public class NavigationMarker : MonoBehaviour
{
    [SerializeField] KeyCode setMarkerButton = KeyCode.E;
    Ray ray;
    [SerializeField] RaycastHit hit;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(setMarkerButton))
        {
            ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            if(Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                NavigationSystem.Instance.target.position = hit.point;
            }
        }
    }
}
