using UnityEngine;
using System.Collections;
using System.Linq;

public class MoveableEnemy : Enemy {
	[SerializeField]
	private float speed = 2.0F;
	[SerializeField]
	private float circleradius = 0.1F;
	[SerializeField]
	private int count = 3;
	[SerializeField]
	private bool isGrounded = false;

	private Vector3 direction;
	private SpriteRenderer sprite;

	protected void Awake (){
		sprite = GetComponentInChildren<SpriteRenderer>();
	}

	protected void Start (){
		direction = transform.right;
	}

	protected void Update (){
		Move ();
	}
	private void CheckGround(){
		Collider2D[] colliders = Physics2D.OverlapCircleAll (transform.position, circleradius);
		isGrounded = colliders.Length > 1;

	}

	private void Move (){
		Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, circleradius);
		if (colliders.Length > count && colliders.All(x => !x.GetComponent<Character>())) {
			direction *= -1.0F;

		}
		transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
	}
}
