﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

    private LevelManager levelManager;

    void OnCollisionEnter2D (Collision2D collision)
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        levelManager.LoadLevel("Lose");
    }
}
