using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrankFunction : MonoBehaviour
{

    public float clickDurationThreshold = 0.5f; // Adjust the threshold as needed
    private float clickStartTime = 0f;
    private bool isMouseButtonDown = false;

    //Jamison's variables
    public float crankHealth = 100f;
    public float bleedDamage = 1f;
    public int bleedRate = 3;
    public bool bleedEnabled = true;
    public bool zeroHealth = false;

    //Jamison learns coroutine
    Coroutine myBleedCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        myBleedCoroutine = StartCoroutine(BleedCoroutine(crankHealth, bleedDamage, bleedRate, bleedEnabled, zeroHealth));
    }

    IEnumerator BleedCoroutine(float crankHealth, float bleedDamage, int bleedRate, bool bleedEnabled, bool zeroHealth)
    {

        bool iFunction = true;
        while (bleedEnabled)
        {
            //Announces bleed has started, will not be called after the first instances.
            if (iFunction == true)
            {
                iFunction = false;
                Debug.Log("Bleed has been enabled");
                Debug.Log("variable CrankHealth has been set to :" + crankHealth.ToString());
            }

            //checks if health is 0. Once 0 has been met, it will then end the while loop.
            if (crankHealth == 0)
            {
                bleedEnabled = false;
                zeroHealth = true;
                Debug.Log("bools: bleedEnabled and zeroHealth have been set to " + bleedEnabled + "and " + zeroHealth + " respectivly.");
            }

            //health is bled here
            crankHealth = crankHealth - bleedDamage;
            Debug.Log("variable CrankHealth has been set to :" + crankHealth.ToString());

            //bleed occurs every x seconds. i nthis case every 3 seconds
            yield return new WaitForSeconds(bleedRate); 
        }
        Debug.Log("Bleed Damage has been disabled. While loop has broke.");
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
