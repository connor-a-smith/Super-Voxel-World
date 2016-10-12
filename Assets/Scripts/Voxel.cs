using UnityEngine;
using System.Collections;

public class Voxel : MonoBehaviour {

  [SerializeField]
  private float moveDuration;

  public static float voxelScale;

  void Awake() {
 
    voxelScale = this.transform.lossyScale.x;

  }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

   /* this.transform.RotateAround(Player.currentPlayer.transform.position,
                                new Vector3(0,1,0),
                                1);
	*/
	}

  public void MoveTo(Vector3 destination) {

    StartCoroutine(Move(destination));

  }

  void SetMoveDuration(float duration) {

    this.moveDuration = duration;

  }

  IEnumerator Move(Vector3 destination) {

    Vector3 startPosition = this.transform.localPosition;

    for (float i = 0; i < moveDuration; i+=Time.deltaTime) {

   
      this.transform.localPosition = Vector3.Lerp(startPosition, destination, i/moveDuration);

      yield return null;

    }

    this.transform.localPosition = destination;

    Debug.Log("FINAL DESTINATION: " + destination);

  }
}
