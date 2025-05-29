using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventManager { 
    public delegate void PlaneEvent();
    public static event PlaneEvent OnPlaneStart;
    public static event PlaneEvent OnPlaneStop;

    public delegate void FuelEvent();
    public static event FuelEvent OnFuelDepleted;

    public delegate void CameraEvent();
    public static event CameraEvent OnCameraFollow;
    
    public delegate void PlaneDeathEvent();
    public static event PlaneDeathEvent OnPlaneDeathEvent;

    // Call this method to trigger the plane start event
    public static void TriggerPlaneStart()
    {
        OnPlaneStart?.Invoke();
    }

    // Call this method to trigger the plane stop event
    public static void TriggerPlaneStop()
    {
        OnPlaneStop?.Invoke();
    }

    // Call this method to trigger the fuel depleted event
    public static void TriggerFuelDepleted()
    {
        OnFuelDepleted?.Invoke();
    }

    // Call this method to trigger the camera follow event
    public static void TriggerCameraFollow()
    {
        OnCameraFollow?.Invoke();
    }

    public static void TriggerPlaneDeathEvent()
    {
        OnPlaneDeathEvent?.Invoke();
    }
}