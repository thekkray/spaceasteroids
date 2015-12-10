using UnityEngine;
using System.Collections;

[RequireComponent( typeof( Rigidbody2D ) )]
public class ApplyRelative2DForceOnEnable : MonoBehaviour
{
	public Vector2 m_RelativeForce = Vector2.zero;

	void OnEnable()
	{
		Rigidbody2D rb = this.GetComponent<Rigidbody2D>() as Rigidbody2D;

		Debug.Assert( rb, "Rigidbody2D component not found!" );

		if( rb )
		{
			rb.AddRelativeForce( m_RelativeForce );
		}
	}
}
