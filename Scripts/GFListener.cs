using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GFListener : AndroidJavaProxy
{
    public delegate void DelegateOnGeoFenceCreateFinished(AndroidJavaObject geoFenceList,int errorCode,string customID);
    public event DelegateOnGeoFenceCreateFinished GeoFenceCreateFinished;

    public GFListener() : base("com.amap.api.fence.GeoFenceListener") { }
    void onGeoFenceCreateFinished(AndroidJavaObject geoFenceList,
           int errorCode,string customID)
    {
        if (GeoFenceCreateFinished != null)
        {
            GeoFenceCreateFinished(geoFenceList,errorCode,customID);
        }
    }

}
