using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flight : MonoBehaviour
{
    public float rotateRate = 45;
    public float translateRate = 1;

    public float xMin = -9;
    public float xMax = 9;
    public float yMin = .5f;
    public float yMax = 2;
    public float zMin = -9;
    public float zMax = 9;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, Time.deltaTime * rotateRate, 0);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, -Time.deltaTime * rotateRate, 0);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Time.deltaTime * translateRate * Vector3.forward);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Time.deltaTime * translateRate * Vector3.back);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Time.deltaTime * translateRate * Vector3.up);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Time.deltaTime * translateRate * Vector3.down);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Time.deltaTime * translateRate * Vector3.left);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Time.deltaTime * translateRate * Vector3.right);
        }
        Vector3 pos = transform.position;

        pos.x = Mathf.Clamp(pos.x, xMin, xMax);
        pos.y = Mathf.Clamp(pos.y, yMin, yMax);
        pos.z = Mathf.Clamp(pos.z, zMin, zMax);

        transform.position = pos;
    }
}
