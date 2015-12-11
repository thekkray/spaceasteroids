using UnityEngine;
using System.Collections;

public class ApplyRandom2DForceOnEnable : MonoBehaviour
{
	public float m_ForceMagnitude = 0.00f;

	void OnEnable()
	{
		Rigidbody2D rb = this.GetComponent<Rigidbody2D>() as Rigidbody2D;

		Debug.Assert( rb, "Rigidbody2D component not found!", this.gameObject );

		if( rb )
		{
			rb.AddRelativeForce( Random.insideUnitCircle * m_ForceMagnitude );
		}
	}
}
