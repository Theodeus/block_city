using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CitizenController : MonoBehaviour {

    public List<GameObject> citizenTypes = new List<GameObject>();

    public int numCitizens = 10;

    private System.Random rand;

    // Use this for initialization
    void Start()
    {
        rand = new System.Random();
        for (var i = 0; i < numCitizens; i++)
        {
            Instantiate(citizenTypes[rand.Next(0, citizenTypes.Count)], new Vector3((float)rand.Next(1, 99), 0.1f, (float)rand.Next(1, 99)), Quaternion.identity);
        }
    }
}
