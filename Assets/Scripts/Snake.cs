using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour, IControllable
{
    public static Vector2 direction;

    private List<Transform> _segments;
    [SerializeField] Transform _segmentPrefab;

    private void Start()
    {
        _segments = new List<Transform>();
        _segments.Add(transform);   
    }

    public void Move()
    {
        for (int i = _segments.Count - 1; i > 0; i--)
        {
            _segments[i].position = _segments[i - 1].position;
        }

        transform.position = new Vector3(
            Mathf.Round(transform.position.x) + direction.x,
            Mathf.Round(transform.position.y) + direction.y,
            0.0f);
    }

    public static void MoveDirection(Vector2 dir)
    {
        direction = dir;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Grow() //рост
    {
        Transform segment = Instantiate(_segmentPrefab);
        segment.position = _segments[_segments.Count - 1].position;
        _segments.Add(segment);
    }

    private void ResetState()
    {
        for (int i = 1; i < _segments.Count; i++)
        {
            Destroy(_segments[i].gameObject);
        }

        _segments.Clear();
        _segments.Add(transform);
        transform.position = Vector3.zero;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Eat") Grow();
        if (collision.tag == "Obstacle") ResetState();
    }
}
