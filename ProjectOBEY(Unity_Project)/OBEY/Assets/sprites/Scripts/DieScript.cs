using UnityEngine;
using UnityEngine.SceneManagement;

public class DieScript : MonoBehaviour {
	public GameObject respawn;
	
	/*void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Player") {
			other.transform.position = respawn.transform.position;
		}
	}*/
		void OnTriggerEnter2D(Collider2D col){
			if (col.gameObject.name == "dieCollider")
			Application.LoadLevel (Application.loadedLevel);
		}

}
