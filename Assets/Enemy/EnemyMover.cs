using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof (Enemy))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private List<WayPoint> _path = new List<WayPoint>();
    [SerializeField] [Range(0f, 5f)] private float _speed = 1f;

    private Enemy enemy;

    void OnEnable()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(FollowPath());
    }

    void Start()
    {
        enemy = GetComponent<Enemy>();    
    }


    private void FindPath()
    {
        _path.Clear();

        GameObject parentOfWayPoints = GameObject.FindGameObjectWithTag("Path");
        foreach(Transform waypoint in parentOfWayPoints.transform)
        {
            WayPoint point = waypoint.GetComponent<WayPoint>();
            if(point!= null)
            {
                _path.Add(point);
            }
        }
    }


    private void ReturnToStart()
    {
        transform.position = _path[0].transform.position;
    }

    private IEnumerator FollowPath()
    {
        foreach (WayPoint waypoint in _path)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = waypoint.transform.position;
            float travelPercent = 0f;

            transform.LookAt(endPosition);

            // "1" - Cause Lerp takes values between 0-1
            while (travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * _speed;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }
        FinishPath();
    }

    private void FinishPath()
    {
        enemy.StealGold();
        gameObject.SetActive(false);
    }
}
