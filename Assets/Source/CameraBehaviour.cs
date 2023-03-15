using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    [SerializeField] Transform originTransform;
    Transform cameraTransform;
    Event onPreRenderEvent;
    void Start()
    {
        
    }
    void OnPreRender()
    {
        //onPreRenderEvent.Call();
    }
}
