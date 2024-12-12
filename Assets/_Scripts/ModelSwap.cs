using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ModelSwap : MonoBehaviour
{
    [SerializeField] GameObject[] objects;
    [SerializeField] int currentIndex;

    // Start is called before the first frame update
    void Start()
    {
        objects = InitializeObjectsArray();
        currentIndex = 0;
        UpdateShownModel();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            NextIndex();
            UpdateShownModel();
        }
        if (Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            PreviousIndex();
            UpdateShownModel();
        }
    }

    GameObject[] InitializeObjectsArray()
    {
        GameObject[] _gameObjects = new GameObject[transform.childCount];
        for (int i = 0; i < _gameObjects.Length; i++)
        {
            _gameObjects[i] = transform.GetChild(i).gameObject;
        }
        return _gameObjects;
    }

    void NextIndex()
    {
        currentIndex++;
        currentIndex %= objects.Length;
    }

    void PreviousIndex()
    {
        currentIndex--;
        if(currentIndex < 0)
            currentIndex = objects.Length-1;
    }

    void UpdateShownModel()
    {
        foreach (GameObject obj in objects)
        {
            obj.SetActive(false);
        }
        objects[currentIndex].SetActive(true);
    }
}
