using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Transform[] m_waypoints;
    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private float m_distanceThreshold;
    [SerializeField] private Transform eyes;
    [SerializeField] private LayerMask bullsEyesLayerMask;
    [SerializeField] private GameObject volumeDetectedPlayerOn;


    private int m_currentWayPointsIndex;

    private void Awake()
    {
        m_currentWayPointsIndex = 0;
    }
    void Update()
    {
        Patrol();
        RayDart();
    }



    public void RecieveWaypoints(Transform[] p_waypoints)
    {
        m_waypoints = p_waypoints;
    }

    //Para listas

    public void AddWaypoint(Transform m_newWaypoint)
    {
        if (!m_waypoints.Contains(m_newWaypoint))
        {
            // m_waypoints = m_waypoints.ToList();
        }


    }


    //Para listas
    public void TryRemoveWayPoint(Transform m_waypointToRemove)
    {
        //if (m_waypoints.Contains(m_newWaypoint))
        //{
        //   m_waypoints.Remove(m_waypoints); 
        //}
    }




    private void Move(Vector3 p_direction)
    {
        transform.position += p_direction * (moveSpeed * Time.deltaTime);
    }

    private void Patrol()
    {
        var l_currentWayPoints = m_waypoints[m_currentWayPointsIndex];
        var l_currDiference = (l_currentWayPoints.position - transform.position);
        var l_direction = l_currDiference.normalized;
        Move(l_direction);

        var l_currDistance = l_currDiference.magnitude;

        if (l_currDistance <= m_distanceThreshold)
        {
            NextWayPoint();
        }

    }
    private void NextWayPoint()
    {

        m_currentWayPointsIndex++;
        if (m_currentWayPointsIndex >= m_waypoints.Length)
        {
            m_currentWayPointsIndex = 0;
        }

    }

    private void RayDart()
    {
        RaycastHit hit;
        Ray ray = new Ray(eyes.position, eyes.forward);
   
        Debug.DrawRay(eyes.position,eyes.forward * 50f, Color.green);

        if (Physics.Raycast(ray, out hit, 50f, bullsEyesLayerMask))
        {
            Debug.Log($"Hit{hit.transform.position}");

            volumeDetectedPlayerOn.SetActive(true);
        }
      
        


    }




}
