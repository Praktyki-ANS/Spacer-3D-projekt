using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    private void Awake()
    {
        Application.targetFrameRate = 60;
    }

    public void LoadInsideScene(int id)
    {
       Application.LoadLevel(id);
    }
}
