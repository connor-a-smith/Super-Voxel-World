using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VoxelConfigurations : MonoBehaviour {

  public bool addConfigMode = false;

  public static List<Vector3> myFirstConfiguration;

  void Awake() {

    myFirstConfiguration = new List<Vector3>();
    Debug.Log("INSIDE: " + myFirstConfiguration);


    for (int i = 0; i < 5; i++) {

      for (int j = 0; j < 5; j++) {

        for (int y = 0; y < 5; y++) {

          myFirstConfiguration.Add(new Vector3(i,j,y));

        }
      }    
    }
  }

	// Use this for initialization
	void Start () {
 
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
