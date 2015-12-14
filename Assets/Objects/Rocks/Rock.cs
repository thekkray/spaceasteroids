using UnityEngine;

[RequireComponent( typeof( Rigidbody2D ) )]
[RequireComponent( typeof( Collider2D ) )]
public class Rock : MonoBehaviour
{
	// events
	public delegate void OnRockEnabledAction( Rock rock );
	public static OnRockEnabledAction OnRockEnabled;
	public delegate void OnRockDisabledAction( Rock rock );
	public static OnRockDisabledAction OnRockDisabled;
	public delegate void OnRockHitAction( Rock rock, Collider2D other );
	public static OnRockHitAction OnRockHit;

	// conf
	public float m_RandomForceMagnitude = 0.00f;
	public int m_Size = 0;

	// private
	Rigidbody2D m_Rigidbody2D = null;

	void Awake()
	{
		m_Rigidbody2D = this.GetComponent<Rigidbody2D>() as Rigidbody2D;

		Debug.Assert( m_Rigidbody2D, "Rigidbody2D component not found!", this.gameObject );
		Debug.Assert( m_Size != 0, "Size should differ from zero!", this.gameObject );

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
		if( m_Rigidbody2D )
		{
			m_Rigidbody2D.AddRelativeForce( Random.insideUnitCircle * m_RandomForceMagnitude );
		}

		if( OnRockEnabled != null )
			OnRockEnabled( this );
	}

	void OnDisable()
	{
		if( OnRockDisabled != null )
			OnRockDisabled( this );
	}

	void OnTriggerEnter2D( Collider2D other )
	{
		if( OnRockHit != null )
			OnRockHit( this, other );
	}
}

