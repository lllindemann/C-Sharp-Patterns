using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

/// <summary>
/// SINGLETON CLASS via Lazy 
/// </summary>
public class Singleton
{
    #region PRIVATE_VARIABLES
    /// <summary>
    /// Singleton instance
    /// </summary>
    private static readonly Lazy<Singleton> lazy = new Lazy<Singleton>(() => new Singleton());

    #region SINGELTON_METHODS
    /// <summary>
    /// function to get Singleton instance
    /// </summary> 
    public static Singleton GetInstance
    {
        get
        {
            return lazy.Value;
        }
    }

    /// <summary>
    /// Constructor Singleton instance
    /// Use this for Initialization
    /// </summary>
    private Singleton()
    {
        //InitializeSingleton();
    }
    #endregion

    #region PUBLIC_METHODS
    /// <summary>
    /// public logic & behaviour
    /// Call via LazySingleton.GetInstance.Logic()
    /// </summary> 
    public void Logic()
    {
        // ...
    }
    #endregion
}
