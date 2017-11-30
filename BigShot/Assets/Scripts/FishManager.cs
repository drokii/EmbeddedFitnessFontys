using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishManager : MonoBehaviour {

    public GameObject fish;

    public float speedModifier;
    public float maximumYSwim;

    public int maximumSwimingTime;

    private float currentSwimmingTime;
    private float timePast;

    private float swimDistanceForEachFrame;

	// Use this for initialization
	void Start () {
        swimDistanceForEachFrame = 0.01f;
    }
	
	// Update is called once per frame
	void Update () {
        //when the current swimming time is not bigger then the maximum time the fish may swim continu swimming
        if (!(currentSwimmingTime >= maximumSwimingTime))
        {
            if (timePast <= speedModifier)
            {
                timePast += Time.deltaTime;
            }
            else
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + swimDistanceForEachFrame);
                timePast = 0;
            }

            currentSwimmingTime += Time.deltaTime;
        }
	}
}
