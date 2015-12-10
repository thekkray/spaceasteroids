using UnityEngine;
using System.Collections;

public class DeactivateOnTriggerEnter : MonoBehaviour
{
	public string m_OtherObjectTag = "";

	void OnTriggerEnter2D( Collider2D other )
	{
		if( other.tag.Equals( m_OtherObjectTag ) )
			this.gameObject.SetActive( false );
	}
}
