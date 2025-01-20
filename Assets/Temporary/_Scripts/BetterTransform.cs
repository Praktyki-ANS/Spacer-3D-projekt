using System.Collections.Generic;
using UnityEngine;

public class BetterTransform : Transform
{
    private Transform transform;
    public int ChildIndex { get; private set; } = 0;

    public BetterTransform(Transform transform)
    {
        this.transform = transform;
    }

    public Transform GetNextChild()
    {
        ChildIndex++;
        ChildIndex %= transform.childCount;
        Transform child = transform.GetChild(ChildIndex);
        return child;
    }

    public Transform GetPreviousChild()
    {
        ChildIndex--;
        if (ChildIndex < 0)
            ChildIndex = transform.childCount-1;

        return transform.GetChild(ChildIndex);
    }

    public List<Transform> GetChildrenExcept(int index)
    {
        List<Transform> children = new List<Transform>();
        foreach (Transform child in transform)
        {
            if(child!=transform.GetChild(index))
                children.Add(child);
        }
        return children;
    }

    public Transform GetLastChild()
    {
        return transform.GetChild(transform.childCount-1);
    }

}
