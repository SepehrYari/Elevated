using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrankFunction : MonoBehaviour
{

    public float clickDurationThreshold = 0.5f; // Adjust the threshold as needed
    private float clickStartTime = 0f;
    private bool isMouseButtonDown = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isMouseButtonDown = true;
            clickStartTime = Time.time;

            // Check if the mouse click hits the GameObject
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    // Object clicked, print a message to the console
                    Debug.Log("Object Clicked: " + gameObject.name);
                }
                else
                {
                    // Another object was clicked, print its name
                    Debug.Log("Other Object Clicked: " + hit.collider.gameObject.name);
                }
            }
            else
            {
                // No object clicked, print a message
                Debug.Log("No Object Clicked");
            }
        }

        if (isMouseButtonDown && Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            float clickDuration = Time.time - clickStartTime;

            // Check if the mouse button has been held down for the required duration
            if (clickDuration >= clickDurationThreshold)
            {
                // Object clicked and held down, print a message to the console
                Debug.Log("Object Clicked and Held Down: " + " & " + clickDuration.ToString("0.0"));

                // Add your CrankFunction code here or call a function
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            isMouseButtonDown = false;
        }
    }
}
