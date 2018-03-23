using System;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    public Camera cam;
    public List<Transform> prefabBuildings;

    private System.Random rand;

    void Start()
    {
        cam = Camera.main;
        rand = new System.Random();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            int layerMask = 1 << 8;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                Debug.Log(hit.point);
                //Debug.DrawLine(ray.origin, hit.point);
                if (Mathf.Floor(hit.point.y) == 0)
                {
                    Instantiate(prefabBuildings[rand.Next(0, prefabBuildings.Count)], new Vector3(Mathf.Floor(hit.point.x), Mathf.Round(hit.point.y), Mathf.Floor(hit.point.z) + 1), Quaternion.identity);
                }
                else
                {
                    
                    Instantiate(prefabBuildings[rand.Next(0, prefabBuildings.Count)], new Vector3(hit.transform.position.x, Mathf.Round(hit.point.y), hit.transform.position.z), Quaternion.identity);
                }
            }
        }
    }
}
