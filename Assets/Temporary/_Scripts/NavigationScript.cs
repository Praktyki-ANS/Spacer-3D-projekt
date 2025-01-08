using UnityEngine;
using UnityEngine.AI;

public class NavigationScript : MonoBehaviour
{
    [SerializeField] Vector3 startPoint;
    [SerializeField] Vector3 targetPoint;
    NavMeshPath path;
    void CalculatePath()
    {
        path = NavMesh.FindClosestEdge
        NavMesh.CalculatePath(startPoint, targetPoint,0,path);
    }
}
