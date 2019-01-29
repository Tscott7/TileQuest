using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
    Vector3 pos;                                // For movement
    Quaternion rotPos;
    public GameObject pauseMenu = null;
    public float speed = 0f;                         // Speed of movement

    void Start()
    {
        rotPos = transform.rotation;        // Take the initial rotation
        pos = transform.position;          // Take the initial position
        if (pauseMenu == null)
        {
            pauseMenu = GameObject.Find("Game/GameCanvas/PausePanel");
        }
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            pauseMenu.SetActive(true);
        }
        if (Input.GetKey(KeyCode.A) && transform.position == pos && transform.position.x > 0)
        {        // Left
            pos += Vector3.left*3;
            rotPos.Set(0, -0.7071f, 0, 0.7071f);
            GetComponent<Animator>().SetTrigger("Walk");
        }
        if (Input.GetKey(KeyCode.D) && transform.position == pos && transform.position.x < 177)
        {        // Right
            pos += Vector3.right*3;
            rotPos.Set(0, 0.7071f, 0, 0.7071f);
            GetComponent<Animator>().SetTrigger("Walk");
        }
        if (Input.GetKey(KeyCode.W) && transform.position == pos && transform.position.z < 120)
        {        // Forward
            pos += Vector3.forward*3;
            rotPos.Set(0, 0, 0, 0);
            GetComponent<Animator>().SetTrigger("Walk");
        }
        if (Input.GetKey(KeyCode.S) && transform.position == pos && transform.position.z > 3)
        {        // Back
            pos += Vector3.back*3;
            rotPos.Set(0, 1, 0, 0);
            GetComponent<Animator>().SetTrigger("Walk");
        }
        transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);    // Move there
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotPos, 360);
    }
}
