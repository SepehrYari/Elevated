using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    public Transform FrontView;
    public Transform LeftView;
    public Transform RightView;
    public Transform TopView;

    public Transform[] positions;
    public float moveSpeed = 5f;
    private int currentPositionIndex = 0;

    void Update()
    {
        // Move towards the target position smoothly
        transform.position = Vector3.Lerp(transform.position, positions[currentPositionIndex].position, Time.deltaTime * moveSpeed);
        transform.rotation = Quaternion.Lerp(transform.rotation, positions[currentPositionIndex].rotation, Time.deltaTime * moveSpeed);

        // Check for input to change the target position
        if (Input.GetKeyDown(KeyCode.W))
            ChangePosition(0);
        else if (Input.GetKeyDown(KeyCode.A))
            ChangePosition(1);
        else if (Input.GetKeyDown(KeyCode.S))
            ChangePosition(2);
        else if (Input.GetKeyDown(KeyCode.D))
            ChangePosition(3);
    }

    void ChangePosition(int index)
    {
        // Update the target position index
        currentPositionIndex = index;
    }
}
