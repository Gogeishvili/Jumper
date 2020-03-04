using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollObject : MonoBehaviour
{
    public float Speed = 5f, CheckPosition = 0f;

    private RectTransform rect;

    void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        

        if (rect.offsetMin.y != CheckPosition)
        {
            rect.offsetMin += new Vector2(rect.offsetMin.x, Speed);
            rect.offsetMax += new Vector2(rect.offsetMax.x, Speed);

        }

    }
}
