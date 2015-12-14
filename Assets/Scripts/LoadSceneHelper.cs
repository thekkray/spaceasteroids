using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneHelper : MonoBehaviour
{
	public void LoadScene( string scene_name )
	{
		SceneManager.LoadScene( scene_name );
	}
}
