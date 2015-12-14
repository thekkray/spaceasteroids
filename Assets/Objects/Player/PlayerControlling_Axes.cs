using UnityEngine;

[RequireComponent( typeof( PlayerMoving ) )]
[RequireComponent( typeof( PlayerShooting ) )]
public class PlayerControlling_Axes : MonoBehaviour
{
	// conf
	public string m_RotateAxis = "Horizontal";
	public string m_AccelerateAxis = "Vertical";
	public string m_ShootAxis = "Fire1";

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
		float rotate_axis_value = Input.GetAxisRaw( m_RotateAxis );
		float accelerate_axis_value = Input.GetAxisRaw( m_AccelerateAxis );

		if( m_PlayerMoving != null )
		{
			if( rotate_axis_value > 0 )
			{
				m_PlayerMoving.StartRotation_Right();
				m_PlayerMoving.StopRotation_Left();
			}
			else
			if( rotate_axis_value < 0 )
			{
				m_PlayerMoving.StartRotation_Left();
				m_PlayerMoving.StopRotation_Right();
			}
			else
			{
				m_PlayerMoving.StopRotation_Right();
				m_PlayerMoving.StopRotation_Left();
			}

			if( accelerate_axis_value > 0 )
			{
				m_PlayerMoving.StartAccellerating();
			}
			else
			{
				m_PlayerMoving.StopAccelerating();
			}
		}

		if( m_PlayerShooting )
		{
			if( Input.GetButtonDown( m_ShootAxis ) )
			{
				m_PlayerShooting.Shoot();
			}
		}
	}
}
