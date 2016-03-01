﻿using UnityEngine;
using System.Collections;

public class Voxel : MonoBehaviour {

  [SerializeField]
  private float moveDuration;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

    this.transform.RotateAround(Player.currentPlayer.transform.position,
                                new Vector3(0,1,0),
                                1);
	
	}

  public void MoveTo(Vector3 destination) {

    StartCoroutine(Move(destination));

  }

  void SetMoveDuration(float duration) {

    this.moveDuration = duration;

  }

  IEnumerator Move(Vector3 destination) {

    float recordedTime = Time.time;

    Vector3 startPosition = this.transform.position;

    Debug.Log("MOVING");


    while (Time.time - recordedTime < moveDuration) {

      this.transform.localPosition = Vector3.Lerp(startPosition, destination, (Time.time - recordedTime) / moveDuration);

      yield return null;

    }
  }
}
