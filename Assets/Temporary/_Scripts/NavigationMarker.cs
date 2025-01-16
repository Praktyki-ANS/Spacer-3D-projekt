using UnityEngine;

public class NavigationMarker : MonoBehaviour
{
    [SerializeField] Navigation navigation;
    [SerializeField] KeyCode setMarkerButton = KeyCode.E;
    Ray ray;
    RaycastHit hit;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(setMarkerButton))
        {
            ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            if(Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                navigation.Target.position = hit.point;
            }
        }
    }
}
