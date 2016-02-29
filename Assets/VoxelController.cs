using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VoxelController : MonoBehaviour {

  public Object voxel;

  public static VoxelController activeController;

  private List<Voxel> freeVoxels;

  void Awake() {

    freeVoxels = new List<Voxel>();
    VoxelController.activeController = this;

    for (int i = 0; i < 50; i++) {


    }

  }

	// Use this for initialization
	void Start () {

 
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

  void AddFreeVoxel(Voxel freeVoxel) {

    freeVoxels.Add(freeVoxel);

  }

  public void RemoveFreeVoxel(Voxel freeVoxel) {

    freeVoxels.Remove(freeVoxel);

  }

  public void RemoveFreeVoxel(int freeVoxelIndex) {

    freeVoxels.RemoveAt(freeVoxelIndex);

  }

  Vector3 GetValidVoxelLocation() {

    //temporary
    return new Vector3(Random.Range(-5f, 5f),
                       Random.Range(-5f, 5f),
                       Random.Range(-5f, 5f)); 

  }

  void SpawnVoxel() {

    GameObject newVoxel = 
      (GameObject)GameObject.Instantiate(voxel, GetValidVoxelLocation(), Quaternion.identity);

    freeVoxels.Add(newVoxel.GetComponent<Voxel>());


  }
 

  public Voxel GetFreeVoxel() {

    if (freeVoxels.Count <= 0) {

      SpawnVoxel();

    }

    int randomVoxelIndex = Random.Range(0, freeVoxels.Count-1);

    Voxel chosenVoxel = freeVoxels[randomVoxelIndex];
    RemoveFreeVoxel(randomVoxelIndex);

    return chosenVoxel;

  }
}
