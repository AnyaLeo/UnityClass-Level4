using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockAgent : MonoBehaviour
{
    public void MoveAgent(Vector3 moveDirection)
    {
        // Rotate us in moveDirection
        transform.up = moveDirection;

        // Move us in moveDirection (because that's what out transform.up is pointing to)
        transform.position += transform.up * Time.deltaTime;
    }
}
