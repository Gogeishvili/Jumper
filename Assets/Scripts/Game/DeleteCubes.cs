using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteCubes : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        print("Shemovida");
        if (other.tag == "Cube")
            Destroy(other.gameObject, 1f);
    }
}
