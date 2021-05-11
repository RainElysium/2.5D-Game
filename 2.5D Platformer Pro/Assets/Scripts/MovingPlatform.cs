using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private Transform[] _waypoints = new Transform[2];
    private float _speed = 2.0f;
    [SerializeField]
    private bool _switching = false;
    private Player _player;
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 currentPos = transform.position;

        if (!_switching)
            transform.position = Vector3.MoveTowards(currentPos, _waypoints[0].position, Time.deltaTime * _speed);
        else
            transform.position = Vector3.MoveTowards(currentPos, _waypoints[1].position, Time.deltaTime * _speed);


        if (currentPos == _waypoints[0].position) // Point A
        {
            transform.position = Vector3.MoveTowards(currentPos, _waypoints[1].position, Time.deltaTime * _speed);
            _switching = true;
        }
        else if (currentPos == _waypoints[1].position) // Point B
        {
            transform.position = Vector3.MoveTowards(currentPos, _waypoints[0].position, Time.deltaTime * _speed);
            _switching = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.parent = this.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            other.transform.parent = null;
    }
}
