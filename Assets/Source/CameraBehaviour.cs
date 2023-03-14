using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    [SerializeField] Transform originTransform;
    Transform cameraTransform;
    IStateHandler stateHandler;
    Event onPreRenderEvent;
    void Start()
    {
        onPreRenderEvent = new Event();
        cameraTransform = gameObject.transform;
        stateHandler = new UnityStateHandler(onPreRenderEvent, new CameraFollowState());
    }
    void OnPreRender()
    {
        onPreRenderEvent.Call();
    }
}
