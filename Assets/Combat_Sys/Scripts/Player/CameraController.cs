using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform followTarget;
    [SerializeField] List<Transform> switchableTargets;

    [SerializeField] float rotationSpeed = 2f;
    [SerializeField] float distance = 5;

    [SerializeField] float minVerticalAngle = -45;
    [SerializeField] float maxVerticalAngle = 45;

    [SerializeField] Vector2 framingOffset;

    [SerializeField] bool invertX;
    [SerializeField] bool invertY;


    float rotationX;
    float rotationY;

    float invertXVal;
    float invertYVal;
    private int currentTargetIndex = 0;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        if (switchableTargets.Count > 0)
        {
            followTarget = switchableTargets[currentTargetIndex];
        }
    }

    private void Update()
    {
        invertXVal =  (invertX) ? -1 : 1;
        invertYVal =  (invertY) ? -1 : 1;

        rotationX += Input.GetAxis("Camera Y") * invertYVal * rotationSpeed;
        rotationX = Mathf.Clamp(rotationX, minVerticalAngle, maxVerticalAngle);

        rotationY += Input.GetAxis("Camera X") * invertXVal * rotationSpeed;

        var targetRotation = Quaternion.Euler(rotationX, rotationY, 0);

        var focusPostion = followTarget.position + new Vector3(framingOffset.x, framingOffset.y);

        transform.position = focusPostion - targetRotation * new Vector3(0, 0, distance);
        transform.rotation = targetRotation;
        
        //CAMERA SWITCH LOGIC
         if (Input.GetKeyDown(KeyCode.T) && switchableTargets.Count > 1)
        {
            SwitchToNextTarget();
        }
    }

    private void SwitchToNextTarget()
    {
        currentTargetIndex = (currentTargetIndex + 1) % switchableTargets.Count;
        followTarget = switchableTargets[currentTargetIndex];
    }


    public Quaternion PlanarRotation => Quaternion.Euler(0, rotationY, 0);
}
