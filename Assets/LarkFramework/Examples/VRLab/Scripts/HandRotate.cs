using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HandRotate : MonoBehaviour {

    #region [mouse ctrl fields]
    //方向灵敏度  
    public float sensitivityX = 10F;
    public float sensitivityY = 10F;

    //上下最大视角(Y视角)  
    public float minimumY = -60F;
    public float maximumY = 60F;

    float rotationY = 0F;
    #endregion

    #region [gyro ctrl fields]
    public bool VrModeEnabled
    {
        get
        {
            return vrModeEnabled;
        }

        set
        {
            vrModeEnabled = value;
        }
    }
    private bool vrModeEnabled = true;

    private Quaternion initialRotation = Quaternion.identity;

    #endregion

    //void Start()
    //{
    //    Input.gyro.enabled = vrModeEnabled;

    //    var fw = Input.gyro.attitude * -Vector3.forward;
    //    fw.z = 0;
    //    if (fw == Vector3.zero)
    //    {
    //        transform.localRotation = Quaternion.identity;
    //    }
    //    else
    //    {
    //        transform.localRotation = Quaternion.FromToRotation(Quaternion.identity * Vector3.up, fw);
    //    }
    //}

    void Update()
    {
#if UNITY_EDITOR
        MouseRotate();
#endif
        //transform.localRotation=GyroRotate();
    }

    private Quaternion GyroRotate()
    {
        var att = Input.gyro.attitude * initialRotation;
        att = new Quaternion(att.x, att.y, -att.z, -att.w);
        return  Quaternion.Euler(90, 0, 0) * att;
    }

    private void MouseRotate()
    {
        if (Input.GetMouseButton(1))
        {
            //根据鼠标移动的快慢(增量), 获得相机左右旋转的角度(处理X)  
            float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;

            //根据鼠标移动的快慢(增量), 获得相机上下旋转的角度(处理Y)  
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            //角度限制. rotationY小于min,返回min. 大于max,返回max. 否则返回value   
            rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

            //总体设置一下相机角度  
            transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
        }
    }
}