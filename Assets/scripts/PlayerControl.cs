using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    [SerializeField] private float controlSpeed = 5;
    [SerializeField] private float yRange = 10;
    [SerializeField] private float xRange = 10;


    [SerializeField] private float positionPitchFactor = -2f;
    [SerializeField] private float postionYawFactor = -2f;


    [SerializeField] private float controlRollFactor = -5f;
    [SerializeField] private float controlPitchFactor = -5f;

    [SerializeField] ParticleSystem  leftLaser;
    [SerializeField] ParticleSystem  rightLaser;

    float xThrow,yThrow;
    
    private void Update() {
        
       ProcessTranlation();
       ProcessRotaion();
       ProcessLaser();
    }

    void ProcessRotaion()
    {
        float pitch = transform.localPosition.y * positionPitchFactor + yThrow * controlPitchFactor;
        float yaw = transform.localPosition.x * postionYawFactor;
        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch,yaw,roll);
    }

    void ProcessTranlation()
    {
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");

        float xOffSet = xThrow * Time.deltaTime * controlSpeed;
        float rawXPos = xOffSet + transform.localPosition.x;
        float clampedX =  Mathf.Clamp(rawXPos,-xRange,xRange);

        float yOffSet = yThrow * Time.deltaTime * controlSpeed;
        float rawYPos = yOffSet + transform.localPosition.y;
        float clampedY = Mathf.Clamp(rawYPos,-yRange,yRange);



        
        transform.localPosition = new Vector3(clampedX,clampedY,transform.localPosition.z);
    }

    public void StopLasers()
    {
        rightLaser.Stop();
        leftLaser.Stop();
    }

    void ProcessLaser()
    {
         if(Input.GetMouseButtonDown(0))
        {
            leftLaser.Play();
        }else if(Input.GetMouseButtonUp(0)){
            leftLaser.Stop();
        }

        if(Input.GetMouseButtonDown(1)){
            rightLaser.Play();
        }else if(Input.GetMouseButtonUp(1)){
            rightLaser.Stop();
        }
    }

}
