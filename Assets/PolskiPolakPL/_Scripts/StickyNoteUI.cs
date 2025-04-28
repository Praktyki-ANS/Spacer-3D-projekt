using UnityEngine;
using TMPro;
public class StickyNoteUI : MonoBehaviour
{
    //Singleton
    public static StickyNoteUI Instance;

    public GameObject StickyNoteGO;
    public TMP_Text contentTextField;
    private void Awake()
    {
        if (Instance && Instance!=this)
            Destroy(this);
        else
            Instance = this;
    }
}
