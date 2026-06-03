using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    [Header("Траектория")]
    [SerializeField] private List<Transform> waypoints;
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private bool loop = true;
    [SerializeField] private float waypointDistance = 0.1f;
    
    private int currentWaypointIndex = 0;
    
    void Update()
    {
        if (waypoints == null || waypoints.Count == 0) return;
        
        Transform targetPoint = waypoints[currentWaypointIndex];
        if (targetPoint == null) return;
        
        // Берём целевую точку, но сохраняем высоту объекта
        Vector3 targetPosition = targetPoint.position;
        targetPosition.y = transform.position.y;
        
        // Направление в плоскости XZ
        Vector3 direction = targetPosition - transform.position;
        direction.y = 0;
        
        float distanceToTarget = direction.magnitude;
        
        if (distanceToTarget < waypointDistance)
        {
            if (currentWaypointIndex + 1 < waypoints.Count)
                currentWaypointIndex++;
            else if (loop)
                currentWaypointIndex = 0;
            else
                return;
            
            targetPoint = waypoints[currentWaypointIndex];
            if (targetPoint == null) return;
            
            targetPosition = targetPoint.position;
            targetPosition.y = transform.position.y;
            direction = targetPosition - transform.position;
            direction.y = 0;
        }
        
        if (direction.magnitude > 0.001f)
        {
            Vector3 moveDirection = direction.normalized;
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
        }
    }
    
    private void OnDrawGizmosSelected()
    {
        if (waypoints == null || waypoints.Count < 2) return;
        
        Gizmos.color = Color.yellow;
        for (int i = 0; i < waypoints.Count - 1; i++)
        {
            if (waypoints[i] != null && waypoints[i+1] != null)
                Gizmos.DrawLine(waypoints[i].position, waypoints[i+1].position);
        }
    }
}
