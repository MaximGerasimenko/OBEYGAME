using UnityEngine;

public class Camera : MonoBehaviour {
	//Szybkosc kamery
	[SerializeField]
	private float speed = 2.0F;

	//Objekt na ktorym bedzie kamera
	[SerializeField]
	private Transform target;

	private void Awake (){
		if (!target)
			target = FindObjectOfType<Character>().transform;
	}
		//zmiana polozenie kamery wedlug X Y (za "targetom")
		//Z - stala = -10.0F
	private void Update (){
		Vector3 position = target.position;
		position.z = -10.0F;
		transform.position = Vector3.Lerp (transform.position, position, speed * Time.deltaTime);
	}

	}
