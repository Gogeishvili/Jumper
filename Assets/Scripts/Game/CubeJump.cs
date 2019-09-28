using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CubeJump : MonoBehaviour
{
    public static bool Jumping , nextBlock;
    public GameObject MainCube,buttons,losebuttons;
    public static int CountBox = 0;
    
    private bool animate, lose;
    private float scratch_speed = 0.5f, startTime, YPosirion;

    private void Awake()
    {
        Jumping = false;
        nextBlock = false;
    }
    private void Start()
    {
        StartCoroutine(CanJump());
    }

    private void FixedUpdate()
    {

        if (animate && MainCube.transform.localScale.y > 0.4f)
            PressCube(-scratch_speed);


        else if (!animate && MainCube!=null)
        {
            if (MainCube.transform.localScale.y < 1f)
                PressCube(scratch_speed * 3f);

            else if (MainCube.transform.localScale.y != 1f)
                MainCube.transform.localScale = new Vector3(1f, 1f, 1f);
        }

        if (MainCube != null)
        {
            if (MainCube.transform.position.y < -3f)
            {
                Destroy(MainCube, 1f);
                print("player death");
                lose = true;
                PlayerLose();
            }
        }
        
    }

    void PlayerLose()
    {
        buttons.GetComponent<ScrollObject>().Speed = 5f;
        buttons.GetComponent<ScrollObject>().CheckPosition = 0;
        if (!losebuttons.activeSelf)
        {
            losebuttons.gameObject.SetActive(true);
            losebuttons.GetComponent<ScrollObject>().CheckPosition = 250;
        }

    }

    private void OnMouseDown()
    {
        if (MainCube.GetComponent<Rigidbody>() && nextBlock)
        {
            animate = true;
            startTime = Time.time;
            YPosirion = Mathf.Round(MainCube.transform.localPosition.y);
        }
    }

    private void OnMouseUp()
    {
        if (MainCube.GetComponent<Rigidbody>() && nextBlock)
        {
            animate = false;

            //jump

            Jumping = true;
            float force, diff;
            diff = Time.time - startTime;

            if (diff < 3f)
                force = 190 * diff;
            else
                force = 300f;
            if (force < 60f)
                force = 60f;

            MainCube.GetComponent<Rigidbody>().AddRelativeForce(MainCube.transform.up * force);
            MainCube.GetComponent<Rigidbody>().AddRelativeForce(MainCube.transform.right * -force);

            StartCoroutine(CheckPosition());
            nextBlock = false;
        }
    }

    void PressCube(float force)
    {
        MainCube.transform.localPosition += new Vector3(0f, force * Time.deltaTime, 0f);
        MainCube.transform.localScale += new Vector3(0f, force * Time.deltaTime, 0f);
    }

    IEnumerator CheckPosition()
    {
        yield return new WaitForSeconds(1f);
        if (YPosirion == Mathf.Round(MainCube.transform.localPosition.y))
        {
            print("Player loss");
            lose = true;
            PlayerLose();
        }
           
        else
        {
            while (MainCube.GetComponent<Rigidbody>().IsSleeping())
            {
                if (MainCube = null)
                    break;

            }

            if (!lose)
            {
                nextBlock = true;
                print("next one");
                CountBox++;
                //kubikis gsasworebeli kodi
                MainCube.transform.localPosition = new Vector3(0.0f, MainCube.transform.localPosition.y,
                    MainCube.transform.localPosition.z);
                MainCube.transform.eulerAngles = new Vector3(1f, MainCube.transform.eulerAngles.y, 1f);
            }
        }
    }
    IEnumerator CanJump()
    {
        while(!MainCube.GetComponent<Rigidbody>())
            yield return new WaitForSeconds(1f);

        nextBlock = true;
    }
}
