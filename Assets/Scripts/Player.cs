using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

  public static Player currentPlayer;

  void Awake() {

    currentPlayer = this;

  }

	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
	
	}

  public Vector3 GetPosition() {

    return this.transform.position;

  }
}
