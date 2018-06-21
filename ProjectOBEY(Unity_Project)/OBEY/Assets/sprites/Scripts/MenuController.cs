using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/*Jest to menu controller*/

public class MenuController : MonoBehaviour {

	public void Level1 ()
	{
		SceneManager.LoadScene ("Scene1");
	}

	public void Level2 ()
	{
		SceneManager.LoadScene ("Scene2");
	}

	public void Level3 ()
	{
		SceneManager.LoadScene ("Scene3");
	}

	public void Level4 ()
	{
		SceneManager.LoadScene ("Scene4");
	}

	public void Level5 ()
	{
		SceneManager.LoadScene ("Scene5");
	}

	public void ExitGame ()
	{
		Application.Quit ();
	}

}
