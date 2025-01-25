using UnityEngine;
using System.Collections;
//--------------------------------------------------------------------
//Follows the player along the 2d plane, using a continuous lerp
//--------------------------------------------------------------------
public class BasicCameraTracker : MonoBehaviour {
    [SerializeField] GameObject m_Target = null;
    [SerializeField] float m_InterpolationFactor = 0.0f;
    [SerializeField] bool m_UseFixedUpdate = false;
    [SerializeField] float m_ZDistance = 10.0f;

    [SerializeField] float minX;
    [SerializeField] float maxX;
    [SerializeField] float minY;
    [SerializeField] float maxY;

    void FixedUpdate () 
	{
        if (m_UseFixedUpdate)
        {
            Interpolate(Time.fixedDeltaTime);
        }
	}

    void LateUpdate()
    {
        if (!m_UseFixedUpdate)
        {
            Interpolate(Time.deltaTime);
        }
    }

    void Interpolate(float a_DeltaTime)
    {
        if (m_Target == null)
        {
            return;
        }
        Vector3 diff = m_Target.transform.position + Vector3.back * m_ZDistance - transform.position;       
        Vector3 newPosition = transform.position + diff * m_InterpolationFactor * a_DeltaTime;

        newPosition.x = Mathf.Min(maxX, Mathf.Max(newPosition.x, minX));
        newPosition.y = Mathf.Min(maxY, Mathf.Max(newPosition.y, minY));

        transform.position = newPosition;
    }

    public void ChangeCameraBounds(float newminX, float newmaxX, float newminY, float newmaxY)
    {
        minX = newminX;
        maxX = newmaxX;
        minY = newminY;
        maxY = newmaxY;
    }
}
