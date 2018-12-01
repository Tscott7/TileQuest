using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameCode : MonoBehaviour {

    private PlayerController PCScript;
    public TMPro.TextMeshProUGUI Days = GameObject.GetComponent<TextMeshProUGUI>();

	// Use this for initialization
	void Start () {
        PCScript = gameObject.GetComponent("PlayerController") as PlayerController;
    }
	
	void Update () {
        
	}

    public void SetPlayerName ()
    {

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
