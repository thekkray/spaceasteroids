using UnityEngine;
using UnityEngine.SceneManagement;

// Notes:
// Helper class to load scenes using UI buttons

public class LoadSceneHelper : MonoBehaviour
{
	public void LoadScene( string scene_name )
	{
		SceneManager.LoadScene( scene_name );
	}
}
