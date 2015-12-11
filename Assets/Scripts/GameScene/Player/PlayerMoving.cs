using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
	public float m_RotationSpeed = 200.0f;
	public float m_AccelerationForce = 8.00f;

	private bool m_RotatingLeft = false;
	private bool m_RotatingRight = false;
	private bool m_Accellerating = false;

	private Vector3 m_Inertia = Vector3.zero;
	private Transform m_StartTransform;

	void Start()
	{
		m_StartTransform = this.transform;
    }

	public void StartRotation_Right()
	{
		m_RotatingRight = true;
	}
	public void StopRotation_Right()
	{
		m_RotatingRight = false;
	}

	public void StartRotation_Left()
	{
		m_RotatingLeft = true;
	}
	public void StopRotation_Left()
	{
		m_RotatingLeft = false;
	}

	public void StartAccellerating()
	{
		m_Accellerating = true;
	}
	public void StopAccelerating()
	{
		m_Accellerating = false;
	}

	void Update()
	{
		this.transform.Translate( m_Inertia * Time.deltaTime, Space.World );

		if( m_RotatingRight && !m_RotatingLeft )
		{
			this.transform.Rotate( Vector3.forward, -Time.deltaTime * m_RotationSpeed );
		}

		if( m_RotatingLeft && !m_RotatingRight )
		{
			this.transform.Rotate( Vector3.forward, Time.deltaTime * m_RotationSpeed );
		}

		if( m_Accellerating )
		{
			m_Inertia += this.transform.up * m_AccelerationForce * Time.deltaTime;
		}
	}

	void ResetToStartPosition()
	{
		this.transform.position = m_StartTransform.position;
		this.transform.rotation = m_StartTransform.rotation;
		m_Inertia = Vector3.zero;
	}

}
