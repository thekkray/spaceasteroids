using UnityEngine;

// Notes:
// If a gameobject it's component attached to tries to move out of the screen
// then the component will bring it back to screen but from other side
// Relies on Camera.main and awaits it will be in orthographic mode

public class ThroughTheEdgeOfScreen : MonoBehaviour
{
	// objects radious for "out of the screen" detecting
	// may be differ from collider's radius, graphics boundary, etc.
	// absolutely independent value
	public float m_ObjectRadius = 0.00f;

	void Awake()
	{
		Debug.Assert( m_ObjectRadius != 0.00f, "Object's Radius is zero. Is it correct?" );
	}

	void Start()
	{
		Debug.Assert( Camera.main, "Camera.main is null!" );

		if( Camera.main )
		{
			Debug.Assert( Camera.main.orthographic, "Camera is not orthographic!" );
		}
	}

	void FixedUpdate()
	{
		if( Camera.main == null )
			return;
		if( !Camera.main.orthographic )
			return;

		float world_h = Camera.main.orthographicSize * 2.00f;
		float world_w = world_h * Camera.main.aspect;

		float world_edge_left = Camera.main.transform.position.x - world_w / 2;
		float world_edge_right = Camera.main.transform.position.x + world_w / 2;
		float world_edge_top = Camera.main.transform.position.y + world_h / 2;
		float world_edge_bottom = Camera.main.transform.position.y - world_h / 2;

		if( this.transform.position.x + m_ObjectRadius < world_edge_left ||
			this.transform.position.x - m_ObjectRadius > world_edge_right ||
			this.transform.position.y - m_ObjectRadius > world_edge_top ||
			this.transform.position.y + m_ObjectRadius < world_edge_bottom
		)
		{
			// we need to use the value less than 1.00f because an object can
			// jab right on the edge of screen. to avoid the issue, we need to slightly
			// move the object to the center of the world
			this.transform.position = this.transform.position * ( -0.999f );
		}
	}
}
