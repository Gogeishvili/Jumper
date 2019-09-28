using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOveCUbes : MonoBehaviour
{
    private bool moved = true;
    private Vector3 target;


    void Start()
    {
        target = new Vector3(-1.39f, 1.7f, 0);
        

    }


    void Update()
    {
        if (CubeJump.nextBlock)
        {
            if (transform.position != target)
                transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * 5f);
            
            else if(transform.position==target && !moved)
            {
                target = new Vector3(transform.position.x - 3f, transform.position.y + 3f, transform.position.z);
                CubeJump.Jumping = false;
                moved = true;
            }
            if (CubeJump.Jumping)
                moved = false;
        }
    }
}
