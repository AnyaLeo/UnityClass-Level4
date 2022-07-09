using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    public GameObject flockAgentPrefab;
    public int flockAgentCount = 10;
    public float spawnRadius = 5f;
    public List<GameObject> flockAgents;

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Initialize()
    {
        for(int i = 0; i < flockAgentCount; i++)
        {
            GameObject newAgent = Instantiate(flockAgentPrefab);
            Vector2 newAgentPosition = Random.insideUnitCircle * spawnRadius;
            newAgent.transform.position = newAgentPosition;

            Vector3 newAgentRotation = new Vector3(0, 0, Random.Range(0f, 360f)); 
            newAgent.transform.eulerAngles = newAgentRotation;

            newAgent.transform.parent = transform;

            flockAgents.Add(newAgent);
        }
    }
}
