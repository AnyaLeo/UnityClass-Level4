using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFlock : MonoBehaviour
{
    public GameObject fishPrefab;
    public int numToSpawn = 30;
    public float spawnDistance = 5f;

    public List<FlockAgent> flockAgents;

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < flockAgents.Count; i++) 
        {
            flockAgents[i].MoveAgent(flockAgents[i].transform.up);
        }
    }

    void Initialize() 
    {
        flockAgents = new List<FlockAgent>();
        for(int i = 0; i < numToSpawn; i++) 
        {
            GameObject newFish = Instantiate(fishPrefab);

            newFish.transform.position = Random.insideUnitCircle * spawnDistance;
            newFish.transform.eulerAngles = new Vector3(0, 0, Random.Range(0f, 360f));
            newFish.transform.SetParent(transform);

            FlockAgent agentScript = newFish.GetComponent<FlockAgent>();
            flockAgents.Add(agentScript);
        }
    }
}
