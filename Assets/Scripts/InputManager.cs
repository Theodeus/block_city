using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour {

    public List<Transform> prefabBuildings;
    public Transform camFocus;
    public float panSensitivity = 0.01f;

    private int buildingIndex;
    private System.Random rand;
    private Vector3 lastMousePosition;
    private Camera cam;

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
            int layerMaskBuildings = 1 << 8;

            if (!EventSystem.current.IsPointerOverGameObject() && Physics.Raycast(ray, out hit, Mathf.Infinity, layerMaskBuildings))
            {
                //Debug.DrawLine(ray.origin, hit.point);
                if (Mathf.Floor(hit.point.y) == 0)
                {
                    Instantiate(prefabBuildings[buildingIndex], new Vector3(Mathf.Floor(hit.point.x), Mathf.Round(hit.point.y), Mathf.Floor(hit.point.z) + 1), Quaternion.identity);
                }
                else
                {
                    Instantiate(prefabBuildings[buildingIndex], new Vector3(hit.transform.position.x, Mathf.Round(hit.point.y), hit.transform.position.z), Quaternion.identity);
                }
            }
        }
        if (Input.GetMouseButton(2))
        {
            Vector3 newRotation = new Vector3(cam.transform.eulerAngles.x, cam.transform.eulerAngles.y, cam.transform.eulerAngles.z);
            Vector3 tmpRotation = camFocus.eulerAngles;
            camFocus.eulerAngles = newRotation;
            Vector3 delta = (Input.mousePosition - lastMousePosition);
            camFocus.Translate(-delta.x * panSensitivity, 0, -delta.y * panSensitivity);
            //compensate for camera angle by moving the focus back up to ground level
            camFocus.Translate(0, -camFocus.position.y, 0);
            camFocus.eulerAngles = tmpRotation;
        }
        lastMousePosition = Input.mousePosition;
    }

    public void setSelected(int type) {
        buildingIndex = type;
    }
}
