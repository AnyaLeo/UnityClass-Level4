using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockAgent : MonoBehaviour
{
    public void MoveAgent()
    {
        transform.position += transform.up * Time.deltaTime;
    }
}
