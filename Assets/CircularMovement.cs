﻿using UnityEngine;
using System.Collections;

public class CircularMovement : MonoBehaviour {

    public Transform center;
    public float degreesPerSecond = -65.0f;

    private Vector3 v;

    void Start() {
        v = transform.position - center.position;
    }

    void Update() {
        v = Quaternion.AngleAxis(degreesPerSecond * Time.deltaTime, Vector3.up) * v;
        transform.position = center.position + v;
    }
}