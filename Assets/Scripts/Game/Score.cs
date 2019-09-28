using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Score : MonoBehaviour
{
    public Text record;
    private Text txt;
    private bool gameStart;

    void Start()
    {
        record.text ="TOP "+ PlayerPrefs.GetInt("Record").ToString();
        txt = GetComponent<Text>();
        CubeJump.CountBox = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if (txt.text == "0")
            gameStart = true;
        if (gameStart)
        {
            txt.text = CubeJump.CountBox.ToString();

            if (PlayerPrefs.GetInt("Record") < CubeJump.CountBox)
            {
                PlayerPrefs.SetInt("Record", CubeJump.CountBox);
                record.text = "TOP "+ PlayerPrefs.GetInt("Record").ToString();

            }

        }
    }
}
