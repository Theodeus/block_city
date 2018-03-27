using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingMenu : MonoBehaviour {

	public InputManager inputManager;

	public void SelectGreen() {
        inputManager.setSelected(BuildingTypes.GREEN);
	}

    public void SelectPink()
    {
        inputManager.setSelected(BuildingTypes.PINK);
    }

    public void SelectBlue()
    {
        inputManager.setSelected(BuildingTypes.BLUE);
    }
}
