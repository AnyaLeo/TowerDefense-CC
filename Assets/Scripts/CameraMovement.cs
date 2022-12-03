using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float cameraSpeed = 2f;
    private float xMax;
    private float yMin;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * cameraSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * cameraSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * cameraSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * cameraSpeed * Time.deltaTime);
        }

        float xPos = Mathf.Clamp(transform.position.x, 0, xMax);
        float yPos = Mathf.Clamp(transform.position.y, yMin, 0);
        transform.position = new Vector3(xPos, yPos, -10f);
    }

    public void SetLimits(Vector3 maxTile) 
    {
        // Let's get the world coordinate of the bottom RHS viewport point
        Vector3 bottomRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 0));

        xMax = maxTile.x - bottomRight.x;
        yMin = maxTile.y - bottomRight.y;
    }
}
