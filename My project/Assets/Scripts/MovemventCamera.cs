using Cntrls;
using UnityEngine;
using Zenject;

public class MovemventCamera : MonoBehaviour
{
    private Transform cameraTarget;
    private float minimumAngle = 70f;
    private float maximumAngle = 310f;
    private float mouseSensitivity = 3f;

    [Inject]
    private void Construct(PlayerCntrl playerCntrl)
    {
        cameraTarget = playerCntrl.transform.Find("CameraTarget");
        
    }
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float aimX = Input.GetAxis("Mouse X");
        float aimY = Input.GetAxis("Mouse Y");
        cameraTarget.rotation *= Quaternion.AngleAxis(aimX * mouseSensitivity, Vector3.up);
        cameraTarget.rotation *= Quaternion.AngleAxis(-aimY * mouseSensitivity, Vector3.right);

        var angleX = cameraTarget.localEulerAngles.x;

        if (angleX > 180 && angleX < maximumAngle)
        {
            angleX = maximumAngle;
        }
        else if (angleX < 180 && angleX > minimumAngle)
        {
            angleX = minimumAngle;
        }

        cameraTarget.localEulerAngles = new Vector3(angleX, cameraTarget.localEulerAngles.y, 0);
    }
}
