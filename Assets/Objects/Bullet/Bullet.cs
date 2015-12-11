using UnityEngine;
using System.Collections;

/// <summary>
/// Bullet
/// Moving using physics/rigidbody
/// Applies StartForce to itself in OnEnable method (suitable for reusing/pooling)
/// If collides with another object with tag from the list, then deactivates itself and another object
/// (different types of Bullets hit different object, for example 'IceBullets' may be useless against 'FireMonsters')
/// </summary>

[RequireComponent( typeof( Rigidbody2D ) )]
[RequireComponent( typeof( Collider2D ) )]
public class Bullet : MonoBehaviour
{
	// events
	public delegate void OnBulletHitAction( Transform bullet_transform );
	public static OnBulletHitAction OnBulletHit;

	// conf
	public Vector2 m_StartRelativeForce = Vector2.zero;
	public string[] m_TagsToDeactivate;

	// private
	private Rigidbody2D m_Rigidbody2D = null;

	void Start()
	{
		m_Rigidbody2D = this.GetComponent<Rigidbody2D>() as Rigidbody2D;

		Debug.Assert( m_Rigidbody2D, "Rigidbody2D component not found!", this.gameObject );
		Debug.Assert( m_TagsToDeactivate.Length > 0, "Please fill a list of tags!", this.gameObject );
		
		// we use OnTriggerEnter2D method, so we should check the collider
		// it should have isTrigger checkbox checked
		Collider2D collider = this.GetComponent<Collider2D>() as Collider2D;
		Debug.Assert( collider, "Collider2D component not found", this.gameObject );
		if( collider )
		{
			Debug.Assert( collider.isTrigger, "Collider should be in trigger mode!", this.gameObject );
		}
	}

	void OnEnable()
	{
		// we apply force here because bullet will be pooled are reused again and again
		// so we can't apply a start force in Start method, we should do it here

		if( m_Rigidbody2D )
		{
			m_Rigidbody2D.AddRelativeForce( m_StartRelativeForce );
		}
	}

	void OnTriggerEnter2D( Collider2D other )
	{
		for( int i = 0; i < m_TagsToDeactivate.Length; i++ )
		{
			if( other.tag.Equals( m_TagsToDeactivate[ i ] ) )
			{
				this.gameObject.SetActive( false );
				other.gameObject.SetActive( false );

				if( OnBulletHit != null )
					OnBulletHit( this.transform );

				break;
			}
		}
	}
}
