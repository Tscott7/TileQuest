using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
public class DisplayText : MonoBehaviour
{
    public RectTransform myPanel;
    public ScrollRect scrollRect;
    public GameObject myTextPrefab;
    public List<string> chatEvents;
    private float nextMessage;
    private int myNumber = 0;
    private GameObject newText;
    // Use this for initialization
    void Start()
    {
        scrollRect.GetComponent<ScrollRect>();
        chatEvents = new List<string>();
        nextMessage = Time.time + 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextMessage && myNumber < chatEvents.Count)
        {
            GameObject newText = (GameObject)Instantiate(myTextPrefab);
            newText.transform.SetParent(myPanel, false);
            newText.GetComponent<Text>().text = chatEvents[myNumber];
            myNumber++;
            nextMessage = Time.time + 1f;
            scrollRect.velocity = new Vector2(0f, 1000f);
        }
    }
}