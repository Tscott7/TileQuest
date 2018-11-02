using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameCode : MonoBehaviour {

    public Text PLAYERNAME;
    Text userNameInputText;
    public GameObject canvas;
    private TextMeshProUGUI name;

	// Use this for initialization
	void Start () {
        userNameInputText = canvas.transform.Find("StartPanel/InputName/PlayerNameText").GetComponent<Text>();
    }
	
	void Update () {
		if(canvas.activeSelf)
        {
            Pause();
        }
	}

    public void SetPlayerName ()
    {
        this.PLAYERNAME = userNameInputText;
    }

    public void Pause ()
    {
        Time.timeScale = 0;
    }

    public void Resume ()
    {
        Time.timeScale = 1;
    }
}
