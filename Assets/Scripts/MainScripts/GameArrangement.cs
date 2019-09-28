using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameArrangement : MonoBehaviour
{
    public GameObject[] CubesDel;
    public Text GameName, PlayButton;
    public GameObject Buttons , MainCube , Cubes, spawn_Block , music;

    public Text record;

    public Animation Block;

    private bool Clicked;

    private void OnMouseDown()
    {
        if (!Clicked)
        {
            StartCoroutine(DelCubes());
            Clicked = true;
            UpdateGameScene();
            MoveButtonsBack();
            CubeSize();
            PlayStartAnimacions();
            record.gameObject.SetActive(true);

            if (music.gameObject.activeSelf)
                music.SetActive(false);

        }
        
    }

    void PlayStartAnimacions()
    {
        MainCube.GetComponent<Animation>().Play("StartGameCube");
        Cubes.GetComponent<Animation>().Play("CubesStartGame");
        StartCoroutine(CubeToBlock());
    }

    void CubeSize()
    {
        MainCube.transform.localScale = new Vector3(1f, 1f, 1f);
    }

    void UpdateGameScene()
    {
        
        PlayButton.gameObject.SetActive(false);
        GameName.text = "0";
    }

    void MoveButtonsBack()
    {
        Buttons.GetComponent<ScrollObject>().Speed = -5f;
        Buttons.GetComponent<ScrollObject>().CheckPosition = -670f;
    }

    IEnumerator DelCubes()
    {
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(0.5f);
            CubesDel[i].GetComponent<FallCubes>().enabled = true;
        }

        spawn_Block.GetComponent<SpawBlock>().enabled = true;
    }

    IEnumerator CubeToBlock()
    {
        yield return new WaitForSeconds(Cubes.GetComponent<Animation>().clip.length);
        Block.Play();
        

        MainCube.AddComponent<Rigidbody>();
    }
   
}
