using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {
    public AudioClip crack;
    private int timesHit;
    private LevelManager levelManager;
    public Sprite[] hitSprites;
    public static int breakableCount = 0;
    bool isBreakable;
    public GameObject smoke;


    // Use this for initialization
    void Start () {
        print(breakableCount);
        isBreakable = (this.tag == "Breakable");
        if (isBreakable)
        {
            breakableCount++;
            print(breakableCount);
        }
        timesHit = 0;
        levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter2D (Collision2D col)
    {
        AudioSource.PlayClipAtPoint(crack, transform.position);
        if (isBreakable) {
            HandleHits();
        }
       
    }

    void HandleHits()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            breakableCount--;
            print(breakableCount);
            levelManager.BrickDestroyed();
            GameObject smokePuff = Instantiate(smoke,transform.position, Quaternion.identity) as GameObject;
            smokePuff.GetComponent<ParticleSystem>().startColor = new Color(1, 0, 1, .5f);
            //gameObject.GetComponent<SpriteRenderer>().color;
            Destroy(gameObject);

        }
        else { LoadSprites(); }
    }
    void LoadSprites()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex]) {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
    }
    void SimulateWin()
    {
        levelManager.LoadNextLevel();
    }
}
