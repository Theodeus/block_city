using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {

    private NavMeshAgent agent;

    public float acceleration = 2f;
    public float deceleration = 60f;
    public float closeEnoughMeters = 4f;

    private Dictionary<string, Color> buildings = new Dictionary<string, Color>();

    void Start()
    {
        agent = gameObject.GetComponentInChildren<NavMeshAgent>();
        buildings.Add("Water", new Color(.4f, .7f, 1));
        buildings.Add("Food", new Color(1, .3f, .6f));
        buildings.Add("Housing", new Color(.5f, 1, .5f));
    }

    void Update()
    {
        if (agent)
        {
            if (agent.hasPath)
            {
                // speed up slowly, but stop quickly
                agent.acceleration = (agent.remainingDistance < closeEnoughMeters) ? deceleration : acceleration;
            }
            else
            {
                // set random destination
                Vector3 destination = new Vector3(Random.Range(0, 10), 0, Random.Range(0, 10));
                agent.SetDestination(destination);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        MeshRenderer mesh = gameObject.GetComponentInChildren<MeshRenderer>();
        Color newColor;
        if (buildings.TryGetValue(other.gameObject.tag, out newColor))
        {
            mesh.material.color = newColor;
        }
    }
}
