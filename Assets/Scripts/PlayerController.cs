using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {

    private NavMeshAgent _agent;
    private Renderer _renderer;
    private MaterialPropertyBlock _propBlock;

    public float acceleration = 2f;
    public float deceleration = 60f;
    public float closeEnoughMeters = 4f;
    public Color startColor;

    private Dictionary<string, Color> buildings = new Dictionary<string, Color>();

    void Start()
    {
        _propBlock = new MaterialPropertyBlock();
        _renderer = GetComponent<Renderer>();
        _agent = gameObject.GetComponentInChildren<NavMeshAgent>();
        buildings.Add("Water", new Color(.4f, .7f, 1));
        buildings.Add("Food", new Color(1, .3f, .6f));
        buildings.Add("Housing", new Color(.5f, 1, .5f));

        _renderer.GetPropertyBlock(_propBlock);
        _propBlock.SetColor("_Color", startColor);
        _renderer.SetPropertyBlock(_propBlock);

        // set random destination
        Vector3 destination = new Vector3(Random.Range(0, 100), 0, Random.Range(0, 100));
        _agent.SetDestination(destination);
    }

    void Update()
    {
        if (_agent)
        {
            if (!_agent.hasPath)
            {
                // set random destination
                Vector3 destination = new Vector3(Random.Range(0, 100), 0, Random.Range(0, 100));
                _agent.SetDestination(destination);
                // speed up slowly, but stop quickly
                //agent.acceleration = (agent.remainingDistance < closeEnoughMeters) ? deceleration : acceleration;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Color newColor;
        if (buildings.TryGetValue(other.gameObject.tag, out newColor))
        {
            _renderer.GetPropertyBlock(_propBlock);
            _propBlock.SetColor("_Color", newColor);
            _renderer.SetPropertyBlock(_propBlock);
        }
    }
}
