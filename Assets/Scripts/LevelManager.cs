using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public void LoadLevel(string name) {
        Application.LoadLevel(name);
        Brick.breakableCount = 0;
        print(Brick.breakableCount);
    }
    public void LoadNextLevel()
    {
        Application.LoadLevel(Application.loadedLevel+1);
        Brick.breakableCount = 0;
    }
    public void BrickDestroyed()
    {
        if (Brick.breakableCount<=0)
        {
            LoadNextLevel();
        }
    }
}