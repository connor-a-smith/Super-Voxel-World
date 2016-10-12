using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VoxelConfigurations : MonoBehaviour {

  public bool addConfigMode = false;
  public GameObject baseForConfig;

  public static List<Vector3> myFirstConfiguration;
  public static List<Vector3> newConfig;
  public static List<Vector3> cube;

  void Awake() {


    myFirstConfiguration = new List<Vector3>();
    cube = new List<Vector3>();
    newConfig = new List<Vector3>();
    makeConfiguration();
    Debug.Log("INSIDE: " + myFirstConfiguration);


    for (int i = 0; i < 5; i++) {
      for (int j = 0; j < 5; j++) {
        for (int y = 0; y < 5; y++) {

          myFirstConfiguration.Add(new Vector3(i,j,y));

        }
      }    
    }

    float cubeLength = 0.5f;

    for (float i = 0; i <= cubeLength; i+= Voxel.voxelScale) {
      for (float j = 0; j <= cubeLength; j+= Voxel.voxelScale) {
        for (float k = 0; k <= cubeLength; k+= Voxel.voxelScale) {

          Debug.Log("VECTOR: " + new Vector3(i, j, k));


          cube.Add(new Vector3(i, j, k));

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

  void makeConfiguration() {

    foreach (Transform child in baseForConfig.GetComponentsInChildren<Transform>()) {

      newConfig.Add(child.transform.localPosition);


    }
  }
}
