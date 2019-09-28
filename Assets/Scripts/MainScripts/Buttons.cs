using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Buttons : MonoBehaviour
{
    public Sprite mus_on, mus_off;

    private void Start()
    {
        if (gameObject.name == "Music")
        {
            if (PlayerPrefs.GetString("Misuc") == "OFF")
            {
                GetComponent<Image>().sprite = mus_off;
                Camera.main.GetComponent<AudioListener>().enabled = false;
            }
        }
    }

    private void OnMouseDown()
    {
        transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
    }

    private void OnMouseUp()
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
    }

    private void OnMouseUpAsButton()
    {
        switch (gameObject.name)
        {
            case "Restart":
                SceneManager.LoadScene("Main");
                break;
            case "facebook":
                Application.OpenURL("https://www.facebook.com/gio.gogeishvili");
                break;
            case "Settings":
                transform.GetChild(0).gameObject.SetActive(!transform.GetChild(0).gameObject.activeSelf);
                break;
            case "Music":
                if (PlayerPrefs.GetString("Music") == "OFF")
                {
                    GetComponent<Image>().sprite = mus_on;
                    PlayerPrefs.SetString("Music", "ON");
                    Camera.main.GetComponent<AudioListener>().enabled = true;
                }
                else
                {
                    GetComponent<Image>().sprite = mus_off;
                    PlayerPrefs.SetString("Music", "OFF");
                    Camera.main.GetComponent<AudioListener>().enabled = false;

                }
                break;
        }
    }
}
