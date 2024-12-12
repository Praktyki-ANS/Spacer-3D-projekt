using UnityEngine;
using UnityEngine.Events;

public class PauseMenuControler : MonoBehaviour
{
    [SerializeField] KeyCode pauseKey = KeyCode.Escape;
    bool isPaused = false;
    public UnityEvent OnPaused;
    public UnityEvent OnResume;
    // Update is called once per frame
    void Update()
    {
        if (!Input.GetKeyDown(pauseKey))
            return;
        if(!isPaused)
            PauseGame();
        else
            ResumeGame();
        isPaused = !isPaused;
    }

    void PauseGame()
    {
        Cursor.lockState = CursorLockMode.Confined;
        OnPaused?.Invoke();
        Time.timeScale = 0.0f;
    }

    void ResumeGame()
    {
        Cursor.lockState= CursorLockMode.Locked;
        OnResume?.Invoke();
        Time.timeScale = 1.0f;
    }
}
