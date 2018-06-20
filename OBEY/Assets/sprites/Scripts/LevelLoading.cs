using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class LevelLoading : Character {

	[SerializeField]
	public int Number = 6; //Ilosc ktora potrzebna dla nastepnego poziomu.
	[SerializeField]
	public string nextlevel ="";
	public GameObject point;
	private bool visible = false;

	protected void Update() {
		if (score >= Number)
			visible = true;
	}

	protected  void OnGUI(){
		if (visible) {
			GUI.Box (new Rect ((Screen.width - 300) / 2, (Screen.height - 300) / 2, 300, 300), "Dialogue");
			GUI.Label (new Rect (new Rect ((Screen.width - 300) / 2, (Screen.height - 270) / 2, 300, 300)), "Level complete!");
			if(GUI.Button(new Rect ((Screen.width - 250)/2, (Screen.height - 250)/2 + 250, 250, 25), "Exit"))
			{
				visible = false;
			}
			if(GUI.Button (new Rect ((Screen.width - 250)/2, (Screen.height - 300)/2 + 250, 250, 25), "Continue"))
			{
				Debug.Log ("Continue");
				visible = false;
				SceneManager.LoadScene(nextlevel);
			}
		}
	
	}
}
