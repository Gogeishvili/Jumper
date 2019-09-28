using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallCubes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0f, 0.1f, 0f);
    }
}
