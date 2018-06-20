using UnityEngine;
using UnityEngine.SceneManagement;

public class Character : Unit {
	
	[SerializeField]
	public float speed = 3F;
	[SerializeField]
	public float force = 3F;
	[SerializeField]
	private int lives = 1;
	[SerializeField]
	private float checkRadius = 0.3F;
	[SerializeField]
	private bool isGrounded = false;

	public int score = 0;

	//Zwiazek miedzy animacjami
	private CharState State
	{
		get { return (CharState)animator.GetInteger ("State"); }
		set { animator.SetInteger ("State", (int) value); }
	}

	private Animator animator;
	private Rigidbody2D rb;
	private SpriteRenderer sprite;
	private int jumps = 0;
	private int max_jumps = 1;


	//Metody dla gracza
	private void Awake (){
		rb = GetComponent <Rigidbody2D> ();
		animator = GetComponent<Animator> ();
		sprite = GetComponentInChildren<SpriteRenderer> ();
	}

	//Metoda Update
	private void Update () {
		if (isGrounded) State = CharState.Idle;

		if (Input.GetButton ("Horizontal"))
			Run ();
		if (Input.GetButtonDown ("Jump"))
			Jump ();

	}

	//Metoda FixedUpdate, w odroznieniu od Update - jest wywolywana w okreslonym obszarze czasu.
	private void FixedUpdate () {
		CheckGround ();
	}

	//Metoda biegu
	private void Run () {

		Vector3 direction = transform.right * Input.GetAxis ("Horizontal");
		transform.position = Vector3.MoveTowards (transform.position, transform.position + direction, speed * Time.deltaTime);
		sprite.flipX = direction.x < 0.0F;

		if (isGrounded) State = CharState.Run;
	}

	//Metoda skoku
	private void Jump () {
		if (Input.GetButtonDown("Jump") && (jumps < max_jumps)) {  //если таймер прыжков меньше 2х,при нажатии клавиши телу дается импульс вверх.
			rb.AddForce (transform.up * force, ForceMode2D.Impulse);
			jumps += 1;
		}
	}
		
	public override void ReceiveDamage(){
		Application.LoadLevel (Application.loadedLevel);
	}


	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.name == "dieCollider")
			Application.LoadLevel (Application.loadedLevel);
		Debug.Log ("Collider");
		if (col.gameObject.name == "shadow") {
			score++;
			Destroy (col.gameObject);
			Debug.Log (score);
		}
	}

	void OnGUI(){
		GUI.Box (new Rect (375, 0, 100, 25), "Score: " + score);
	}

	//Metoda sprawdzajaca czy stoi objekt na ziemlie
	private void CheckGround(){
		Collider2D[] colliders = Physics2D.OverlapCircleAll (transform.position, checkRadius);
		isGrounded = colliders.Length > 1;
		if (isGrounded) jumps = 0;
		if (!isGrounded) State = CharState.Jump;
	}
}

//Lista animacij
public enum CharState
{
	Idle, //0
	Run, //1
	Jump //2
}