using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VoxelBase : Voxel {


  public float grabDelay = 0.1f;
  public int grabAmount = 20;

  //list of voxels that are part of this base
  private List<Voxel> voxels;

  //list of avaiable vector positions for vectors
  private List<Vector3> freePositions;

  void Awake() {

    voxels = new List<Voxel>();

  }

	// Use this for initialization
	void Start () {

    this.freePositions = new List<Vector3>();
    loadConfiguration();
	
	}
	
	// Update is called once per frame
	void Update () {


	}

  public Vector3 getFreePosition() {

    int randomIndex = Random.Range(0, freePositions.Count-1);
    Debug.Log("INDEX: " + randomIndex + " AND SIZE: " + freePositions.Count);
    Vector3 freePosition = (Vector3)freePositions[randomIndex];
    freePositions.RemoveAt(randomIndex);

    return freePosition;


  }

  void loadConfiguration() {

    freePositions = VoxelConfigurations.cube;
    StartCoroutine(assembleVoxels());

  }

  IEnumerator assembleVoxels() {

    while (freePositions.Count > 0) {

        Voxel newVoxel = VoxelController.activeController.GetFreeVoxel();
     
        newVoxel.transform.parent = this.transform;
        newVoxel.MoveTo(getFreePosition()); 
        voxels.Add(newVoxel);

        Debug.Log("FREE POSITIONS: " + freePositions.Count);


      yield return new WaitForSeconds(grabDelay);

    }
  }
}
