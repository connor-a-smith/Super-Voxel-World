using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

  public static Player currentPlayer;

	// Use this for initialization
	void Start () {

    currentPlayer = this;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

  public Vector3 GetPosition() {

    return this.transform.position;

  }
}
