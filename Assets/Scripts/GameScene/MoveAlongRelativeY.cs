using UnityEngine;
using System.Collections;

public class MoveAlongRelativeY : MonoBehaviour
{
	public float m_Speed = 10.0f;
	
	void Update()
	{
		this.transform.Translate( Vector3.up * m_Speed * Time.deltaTime );
	}
}
