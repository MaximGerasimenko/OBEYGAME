using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class LevelLoading : Character {

	[SerializeField]
	public int Number = 6; //Ilosc(Score) ktora potrzebna dla nastepnej sceny.
	//Nastepna scena. Jest przypisana dynamicznie.
	[SerializeField]
	public string nextlevel ="";
	public GameObject point;
	private bool visible = false;

	protected void Update() {
		//Jezeli grac nabral potrzebna ilosc, to otworz nastepna scene.
		if (score >= Number)
			visible = true;
	}

	//Interfejs
	protected  void OnGUI(){
		if (visible) {
			GUI.Box (new Rect ((Screen.width - 300) / 2, (Screen.height - 300) / 2, 300, 300), "Dialogue");
			GUI.Label (new Rect (new Rect ((Screen.width - 300) / 2, (Screen.height - 270) / 2, 300, 300)), "Level complete!");
			if(GUI.Button(new Rect ((Screen.width - 250)/2, (Screen.height - 250)/2 + 250, 250, 25), "Exit"))
			{
				Debug.Log ("Exit");
				visible = false;
				SceneManager.LoadScene("Menu");
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
