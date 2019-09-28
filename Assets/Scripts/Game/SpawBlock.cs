using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawBlock : MonoBehaviour
{
    public GameObject Block , allCubes;

    private GameObject blockInst;
    private Vector3 blockPos;
    private float speed = 5f;
    private bool onPlace;

    void Start()
    {
        Spawn();
    }

    private void Update()
    {
        if (blockInst.transform.position != blockPos && !onPlace)
        {
            blockInst.transform.position = Vector3.MoveTowards(blockInst.transform.position,
                blockPos, Time.deltaTime * speed);
        }

        else if (blockInst.transform.position == blockPos)
            onPlace = true;

        if(CubeJump.Jumping && CubeJump.nextBlock)
        {
            Spawn();

            onPlace = false;

        }
    }

    void Spawn()
    {
        blockPos = new Vector3(Random.Range(1f, 1.8f), Random.Range(-1f, 0f), 0f);
        blockInst = Instantiate(Block,
            new Vector3(Random.Range(4f, 5f),
            Random.Range(-4f, -3f), 0f),
            Quaternion.identity) as GameObject;
        blockInst.transform.parent = allCubes.transform;

    }
    
}
