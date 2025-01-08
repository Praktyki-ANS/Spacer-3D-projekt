using UnityEngine;
using UnityEngine.AI;
public class NavigationSystem : MonoBehaviour
{
    public static NavigationSystem Instance;

    public Transform origin;
    public Transform target;

    [SerializeField] float refreshTime = 0.1f;
    [SerializeField] float heightOffset = 0.5f;
    [SerializeField] LineRenderer pathRenderer;

    PolskiPolakPL.Utils.Timer refreshTimer;
    NavMeshPath path;


    void Awake()
    {
        if(Instance && Instance!=this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        path = new NavMeshPath();
        refreshTimer = new PolskiPolakPL.Utils.Timer(refreshTime, true);
        refreshTimer.OnTimerEnd += DrawPath;
    }

    private void Update()
    {
        refreshTimer.Tick(Time.deltaTime);
    }

    void DrawPath()
    {
        if (!target || !origin)
            return;
        if (NavMesh.CalculatePath(origin.position, target.position,NavMesh.AllAreas, path))
        {
            pathRenderer.positionCount = path.corners.Length;
            for (int i = 0; i < path.corners.Length; i++)
            {
                pathRenderer.SetPosition(i, path.corners[i] + Vector3.up * heightOffset);
            }
        }
        else
        {
            Debug.LogError($"Unable to calculate path between {origin.position} and {target.position}!");
        }
    }

    private void OnDestroy()
    {
        refreshTimer.OnTimerEnd -= DrawPath;
    }
}