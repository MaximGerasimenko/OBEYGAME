using UnityEngine;

public class Enemy : MonoBehaviour {

	private Animator animator;
	private Rigidbody2D rb;
	private SpriteRenderer sprite;
	private Vector3 direction;


	private void Awake (){
	
		sprite = GetComponentInChildren<SpriteRenderer>();
	}

	private void OnTriggerEnter2D(Collider2D collider)
	{
		Unit unit = collider.GetComponent<Unit> ();
		if (unit && unit is Character)
			unit.ReceiveDamage ();
	}

	private void Update (){
	}

}

