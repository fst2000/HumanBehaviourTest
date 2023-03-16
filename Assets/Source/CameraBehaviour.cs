using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    [SerializeField] Transform originTransform;
    ICameraState stateMachine;
    void Start()
    {
        stateMachine = new CameraStateMachine(new CameraFollowState());
    }
    void OnPreRender()
    {
        transform.position = originTransform.position + originTransform.TransformDirection(stateMachine.CameraInfo().Offset());
        transform.rotation = originTransform.rotation;
    }
}
