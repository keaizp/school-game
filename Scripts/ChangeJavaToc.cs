
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeJavaToC : AndroidJavaProxy
{
    public ChangeJavaToC() : base("com.amap.api.location.AMapLocationListener"){ }
    public delegate void DelegateOnLocationChanged(AndroidJavaObject amap);
    public event DelegateOnLocationChanged locationChanged;

    void onLocationChanged(AndroidJavaObject amapLocation)
    {
        if (locationChanged != null)
        {
            locationChanged(amapLocation);
        }
    }


}