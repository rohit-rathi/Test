using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RaycastTest : MonoBehaviour {

	Vector3 touchPosWorld;
	public Text myText;

	//Change me to change the touch phase used.
	TouchPhase touchPhase = TouchPhase.Began;

	public GameObject particle;

	bool startMoving = false;


	void Update() {

		for (var i = 0; i < Input.touchCount; ++i) {
			if (Input.GetTouch(i).phase == TouchPhase.Began) {

				// Construct a ray from the current touch coordinates
				Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
				// Create a particle if hit
				RaycastHit hit;
				if (Physics.Raycast (ray, out hit)) {
					//Instantiate(particle, transform.position, transform.rotation);     
					startMoving = true;
					myText.text = "Hit";
				}
				if(hit.collider != null){
					GameObject touchedObject = hit.transform.gameObject;
					myText.text += ": " + touchedObject.transform.name;
					if (touchedObject.transform.name == "Cube")
						startMoving = true;
				} 
			}
		}
		if (startMoving) {
			particle.transform.Translate (0, Mathf.Sin (Time.time) * 0.02f, 0, Space.World);
		}
	}
}