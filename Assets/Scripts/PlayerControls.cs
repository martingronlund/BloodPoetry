﻿using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {
    /* Fields */
    public int playerIndex;
    new public Camera camera;

    /* Methods */
    void Start() {
	}

    void Update() {
        camera.transform.Translate(Input.GetAxis( "Horizontal " + playerIndex.ToString() ), 0, 0);
    }
}
