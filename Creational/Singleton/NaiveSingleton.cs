using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

/// <summary>
/// Naive SINGLETON CLASS
/// This kind of Singleton is a very simple, 
/// but loose implementation of a Singleton Pattern
/// Side Effects can be caused in multi-threaded environments
/// cos multiple threads may call the GetInstance() at the same time 
/// which can cause the creation of multiple instances of the Singleton class (paradox).
/// </summary>
public class Singleton
{
    #region PRIVATE_VARIABLES
    /// <summary>
    /// Constructor Singleton instance
    /// should always be private 
    /// to prevent direct construction calls
    /// </summary>
    private Singleton()
    {
        //empty
    }

    // Singleton's instance 
    private static Singleton _instance;

    #region SINGELTON_METHODS
    /// <summary>
    /// function to get Singleton instance
    /// </summary> 
    public static Singleton GetInstance
    {
        if (_instance == null)
        {
            _instance = new Singleton()
        }
        return _instance;
    }
    #endregion

    #region PUBLIC_METHODS
    /// <summary>
    /// public logic & behaviour
    /// Call via Singleton.GetInstance.Logic()
    /// </summary> 
    public void Logic()
    {
        // ...
    }
    #endregion
}
