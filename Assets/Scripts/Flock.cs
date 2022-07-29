using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    public GameObject flockAgentPrefab;
    public int flockAgentCount = 10;
    public float spawnRadius = 5f;
    public List<FlockAgent> flockAgents;

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < flockAgents.Count; i++)
        {
            List<Transform> neighbors = GetNearbyObjects(flockAgents[i]);
            Vector3 alignmentDirection = CalculateAlignment(flockAgents[i], neighbors);
            Vector3 cohesionDirection = CalculateCohesion(flockAgents[i], neighbors);

            Vector3 moveDirection = alignmentDirection + cohesionDirection;

            flockAgents[i].MoveAgent(moveDirection);

            // DEMO ONLY
            // Test code
            // The greener the agent, the more neighbors they've got
            // This line of code is very slow for performance
            // flockAgents[i].GetComponent<SpriteRenderer>().color = Color.Lerp(Color.white, Color.green, neighbors.Count / 6f);
        }
    }

    Vector3 CalculateAlignment(FlockAgent agent, List<Transform> neighbors)
    {
        Vector3 direction = new Vector3();

        // If no neighbors, we want to return our original direction
        if (neighbors.Count == 0)
        {
            return agent.transform.up;
        }

        // Get the average direction of where our neighbors are going
        for(int i = 0; i < neighbors.Count; i++)
        {
            direction = direction + neighbors[i].transform.up;
        }
        direction = direction / neighbors.Count;

        return direction;
    } 

    Vector3 CalculateCohesion(FlockAgent agent, List<Transform> neighbors)
    {
        // If we have no neighbors, return zero
        if (neighbors.Count == 0)
        {
            return Vector3.zero;
        }

        // Get the average position of our neighbors
        Vector3 direction = new Vector3();
        for (int i = 0; i < neighbors.Count; i++)
        {
            direction = direction + neighbors[i].transform.position;
        }
        direction = direction / neighbors.Count;

        // Create offset from our agent position
        direction = direction - agent.transform.position;

        return direction;
    }

    Vector3 CalculateAvoidance(FlockAgent agent, List<Transform> neighbors)
    {
        // If we have no neighbors, return zero
        if (neighbors.Count == 0)
        {
            return Vector3.zero;
        }

        // Calculate avoidance 
        Vector3 direction = new Vector3();
        int numToAvoid = 0;
        float squareAvoidanceRadius = 2f * 2f;

        for(int i = 0; i < neighbors.Count; i++)
        {

        }

        return direction;
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

            FlockAgent newFlockAgent = newAgent.GetComponent<FlockAgent>();
            flockAgents.Add(newFlockAgent);
        }
    }

    List<Transform> GetNearbyObjects(FlockAgent agent)
    {
        List<Transform> neighbors = new List<Transform>();

        Collider2D[] neighborColliders = Physics2D.OverlapCircleAll(agent.transform.position, 2f);
        Collider2D agentCollider = agent.gameObject.GetComponent<Collider2D>();

        for (int i = 0; i < neighborColliders.Length; i++)
        {
            if(neighborColliders[i] != agentCollider)
            {
                neighbors.Add(neighborColliders[i].transform);
            }
        }

        return neighbors;
    }
}
