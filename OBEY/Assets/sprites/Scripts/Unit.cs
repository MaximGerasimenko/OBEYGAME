using UnityEngine;

public class Unit : MonoBehaviour {

	public virtual void ReceiveDamage(){
		Die ();
	}

	public virtual void Die(){
		Destroy (gameObject);
	}

}
