using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
	// conf
	public float m_RotationSpeed = 200.0f;
	public float m_AccelerationForce = 8.00f;
	public float m_DampingFactor = 0.10f;

	// private
	private bool m_RotatingLeft = false;
	private bool m_RotatingRight = false;
	private bool m_Accellerating = false;

	private Vector3 m_Inertia = Vector3.zero;
	private Vector3 m_StartPosition = Vector3.zero;
	private Quaternion m_StartRotation = Quaternion.identity;

	void Start()
	{
		m_StartPosition = this.transform.position;
		m_StartRotation = this.transform.rotation;
    }

	void Update()
	{
		// Rotating
		if( m_RotatingRight && !m_RotatingLeft )
		{
			this.transform.Rotate( Vector3.forward, -Time.deltaTime * m_RotationSpeed );
		}
		else
		if( m_RotatingLeft && !m_RotatingRight )
		{
			this.transform.Rotate( Vector3.forward, Time.deltaTime * m_RotationSpeed );
		}

		// Moving
		this.transform.Translate( m_Inertia * Time.deltaTime, Space.World );
		if( m_Accellerating )
		{
			m_Inertia += this.transform.up * m_AccelerationForce * Time.deltaTime;
		}
		else
		{
			m_Inertia = Vector3.Lerp( m_Inertia, Vector3.zero, m_DampingFactor * Time.deltaTime );
		}
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

	public void ResetToStartPosition()
	{
		this.transform.localPosition = m_StartPosition;
		this.transform.localRotation = m_StartRotation;
		m_Inertia = Vector3.zero;
	}

}
