using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraNodeSwapper : MonoBehaviour
{
    public AudioClip swapCameraSound;
    public AudioSource swapCameraSoundSource;
    public float swapSoundVolume = 0.8f;
    [Space(10)]
    public ChecklistStatus checklistStatus;
    public List<CameraNode> cameraNodes = new List<CameraNode>();
    public ObjectFollower cameraFollowComponent;
    public int currentNodeIndex;

    void Start(){}
    void Update(){}
    void OnDrawGizmos(){}

    public void SetCameraNode(int newCameraNodeIndex){
        // exists and not already there?
        if((newCameraNodeIndex < cameraNodes.Count)&&(newCameraNodeIndex != currentNodeIndex)){
            // ask to move
            cameraFollowComponent.SetNewTarget(cameraNodes[newCameraNodeIndex].transform);
            // make sound
            swapCameraSoundSource.PlayOneShot(swapCameraSound, swapSoundVolume);
            // save where we're going
            currentNodeIndex = newCameraNodeIndex;
        }
    }
    public void PrevCamera(){
        SetCameraNode((cameraNodes.Count+(currentNodeIndex-1))%(cameraNodes.Count));
        if(checklistStatus!=null){ checklistStatus.MarkItemDone(0); }
    }
    public void NextCamera(){
        SetCameraNode((currentNodeIndex+1)%(cameraNodes.Count));
        if(checklistStatus!=null){ checklistStatus.MarkItemDone(0); }
    }
}
