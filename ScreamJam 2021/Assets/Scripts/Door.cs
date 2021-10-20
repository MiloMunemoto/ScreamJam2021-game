using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField,Range(0f, 2f)] private float speed;

    public GameObject leftDoor;
    public GameObject rightDoor;

    private Vector3 leftDoorStartPos;
    private Vector3 rightDoorStartPos;

    private float t = 0;
    private float targetT = 0;

    void Start()
    {
        leftDoorStartPos = leftDoor.transform.position;
        rightDoorStartPos = rightDoor.transform.position;
    }

    void Update()
    {
        t = Mathf.Lerp(t, targetT, Time.deltaTime * speed);
        leftDoor.transform.position = leftDoorStartPos - transform.right * t;
        rightDoor.transform.position = rightDoorStartPos + transform.right * t;
    }

    public void Open()
    {
        targetT = 1f;
    }

    public void Close()
    {
        targetT = 0f;
    }
}
