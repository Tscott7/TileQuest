using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoRotateCam : MonoBehaviour {
    public float cameraDistOffset = 10;
    private Camera mainCamera;
    private GameObject player;

    // Use this for initialization
    void Start()
    {
        mainCamera = GetComponent<Camera>();
        player = GameObject.Find("Game/Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerInfo = player.transform.transform.position;
        mainCamera.transform.position = new Vector3(playerInfo.x, playerInfo.y + 10, playerInfo.z - cameraDistOffset);
        mainCamera.transform.rotation = new Quaternion(0.3f, 0, 0, 1f);
    }
}
