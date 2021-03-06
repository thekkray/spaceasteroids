﻿using UnityEngine;

// Notes:
// PlayerControlling_Axes controls PlayerMoving and PlayerShooting components
// using direct links to component. I prefer to use direct links instead of SendMessage
// if I know what component I'm going to control.
// Compomenent is configurable in Ediator using it's public fields

[RequireComponent( typeof( PlayerMoving ) )]
[RequireComponent( typeof( PlayerShooting ) )]
public class PlayerControlling_Keyboard : MonoBehaviour
{
	// conf
	public KeyCode m_RotateRightKey = KeyCode.RightArrow;
	public KeyCode m_RotateLeftKey = KeyCode.LeftArrow;
	public KeyCode m_AccelerateKey = KeyCode.UpArrow;
	public KeyCode m_ShootKey = KeyCode.LeftControl;

	// private
	private PlayerMoving m_PlayerMoving = null;
	private PlayerShooting m_PlayerShooting = null;

	void Awake()
	{
		m_PlayerMoving = this.GetComponent<PlayerMoving>() as PlayerMoving;
		Debug.Assert( m_PlayerMoving, "PlayerMoving component not found!" );

		m_PlayerShooting = this.GetComponent<PlayerShooting>() as PlayerShooting;
		Debug.Assert( m_PlayerShooting, "m_PlayerShootin gcomponent not found!" );
	}

	void Update()
	{
		if( m_PlayerMoving != null )
		{
			if( Input.GetKeyDown( m_RotateRightKey ) )
				m_PlayerMoving.StartRotation_Right();
			if( Input.GetKeyUp( m_RotateRightKey ) )
				m_PlayerMoving.StopRotation_Right();

			if( Input.GetKeyDown( m_RotateLeftKey ) )
				m_PlayerMoving.StartRotation_Left();
			if( Input.GetKeyUp( m_RotateLeftKey ) )
				m_PlayerMoving.StopRotation_Left();

			if( Input.GetKeyDown( m_AccelerateKey ) )
				m_PlayerMoving.StartAccellerating();
			if( Input.GetKeyUp( m_AccelerateKey ) )
				m_PlayerMoving.StopAccelerating();
		}

		if( m_PlayerShooting != null )
		{
			if( Input.GetKeyDown( m_ShootKey ) )
				m_PlayerShooting.Shoot();
		}
	}
}
