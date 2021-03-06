﻿using UnityEngine;

// Notes:
// Deactivates a gameobject it's connected to on leaving of screen
// Uses current main Camera and awaits it will be in an orthographic mode

public class DeactivateOnLeaveScreen : MonoBehaviour
{
	// objects radious for "out of the screen" detecting
	// may be differ from collider's radius, graphics boundary, etc.
	// absolutely independent value
	public float m_ObjectRadius = 0.00f;

	void Awake()
	{
		Debug.Assert( m_ObjectRadius != 0.00f, "Object's Radius is zero. Is it correct?" );
		Debug.Assert( Camera.main, "Camera.main is null!" );

		if( Camera.main )
		{
			Debug.Assert( Camera.main.orthographic, "Camera is not orthographic!" );
        }
	}

	void Update()
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
			this.gameObject.SetActive( false );
		}
	}
}
