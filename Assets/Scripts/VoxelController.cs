using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VoxelController : MonoBehaviour {

  public Object voxel;
  public float spawnSphereRadius = 5;

  public static VoxelController activeController;

  private List<Voxel> freeVoxels;

  void Awake() {

    freeVoxels = new List<Voxel>();
    VoxelController.activeController = this;

    for (int i = 0; i < 20000; i++) {

      SpawnVoxel();

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
    //return this.transform.position + new Vector3(Random.Range(-5f, 5f),
      //                 Random.Range(-5f, 5f),
        //               5); 

    float theta = 0, phi = 0;

      theta = 2*Mathf.PI*Random.Range(0f, 1f);
      phi = Mathf.Acos((2f * Random.Range(0f, 1f)) - 1f);

      Vector3 sphereCoords = new Vector3(
        Mathf.Cos(theta) * Mathf.Sin(phi),
        Mathf.Sin(theta) * Mathf.Sin(phi),
        Mathf.Cos(phi));

      sphereCoords *= spawnSphereRadius;
      sphereCoords += Player.currentPlayer.transform.position;

      return sphereCoords;

  }

  Voxel SpawnVoxel() {

    GameObject newVoxel = 
      (GameObject)GameObject.Instantiate(voxel, GetValidVoxelLocation(), Quaternion.identity);

    freeVoxels.Add(newVoxel.GetComponent<Voxel>());

    return newVoxel.GetComponent<Voxel>();


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
