using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VoxelBase : Voxel {

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
    Debug.Log(freePositions);
    loadConfiguration();
	
	}
	
	// Update is called once per frame
	void Update () {


	}

  public Vector3 getFreePosition() {

    int randomIndex = Random.Range(0, freePositions.Count-1);
    Vector3 freePosition = (Vector3)freePositions[randomIndex];
    freePositions.RemoveAt(randomIndex);

    return freePosition;


  }

  void loadConfiguration() {

    freePositions = VoxelConfigurations.newConfig;
    StartCoroutine(assembleVoxels());

  }

  IEnumerator assembleVoxels() {

    while (freePositions.Count > 0) {

      Voxel newVoxel = VoxelController.activeController.GetFreeVoxel();
     
      Debug.Log("HERE"); 
      newVoxel.transform.parent = this.transform;
      newVoxel.MoveTo(getFreePosition());
      voxels.Add(newVoxel);

      yield return null;

    }
  }
}
