using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DayDecrease : MonoBehaviour {

    private TextMeshProUGUI textMesH;
    public int counter;

	void Start () {
        textMesH = GetComponent<TextMeshProUGUI>();
        counter = 100;
}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void countdown()
    {
        if (counter == 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
        counter -= 1;
        textMesH.text = counter.ToString();
    }
}
