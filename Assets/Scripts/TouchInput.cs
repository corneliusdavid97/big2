using UnityEngine;
using System.Collections;

public class TouchInput : MonoBehaviour {
	RaycastHit hit;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonUp(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit))
			{
                
				GameObject touchedObject = hit.collider.gameObject;
				CardController touchedCard = touchedObject.GetComponent<CardController>();
				//Debug.Log(touchedObject);
				if (touchedCard != null)
				{
					touchedObject.SendMessage("OnTouched");
				}
			}
		}
	}
}
