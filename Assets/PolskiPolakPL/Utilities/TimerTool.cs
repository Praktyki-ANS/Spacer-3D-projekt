using UnityEngine;
using PolskiPolakPL.Utils;
using UnityEngine.Events;

public class TimerTool : MonoBehaviour
{
    [Tooltip("Sets time of the timer instance. (in seconds)")]
    [SerializeField] float time;
    [Tooltip("Checks if timer loops multiple times.")]
    [SerializeField] bool isTimerLooping;
    [Tooltip("How many times does the timer loop before stopping. If set to 0 it will loop infinitely.")]
    [SerializeField] int loopAmount = 0;
    [Tooltip("Public Event invoked every time the timer elapses.")]
    public UnityEvent OnTimerElapsed;
    int loopCount = 0;
    Timer timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = new Timer(time, isTimerLooping);
        timer.OnTimerEnd += HandleTimerEnd;
    }

    // Update is called once per frame
    void Update()
    {
        timer.Tick(Time.deltaTime);
        if ( loopCount == loopAmount && loopAmount > 0)
            timer.IsLooping = false;
    }

    void HandleTimerEnd()
    {
        loopCount++;
        OnTimerElapsed?.Invoke();
    }

    private void OnDestroy()
    {
        timer.OnTimerEnd -= HandleTimerEnd;
    }

}
