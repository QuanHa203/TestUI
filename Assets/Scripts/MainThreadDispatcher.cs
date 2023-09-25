using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

public class MainThreadDispatcher : MonoBehaviour
{
    private static MainThreadDispatcher instance;

    static Action ac = null;

    public const string MAIN_THREAD_NAME = "MainThread";
    public static bool isMainThread()
    {
        return Thread.CurrentThread.Name == MAIN_THREAD_NAME;
    }
    private void Awake()
    {

        if (instance != null)
        {
            Destroy(this);
            return;
        }
        // ----------ALL CODE BELOW THHIS LINNE----------
        try
        {
            Thread.CurrentThread.Name = MAIN_THREAD_NAME;
        }
        catch
        {
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {

        if (ac != null)
        {
            lock (lockobj)
            {
                ac();
            }
            ac = null;
        }
    }
    static object lockobj = new object();
    public static void ExecuteInMainThread(Action action)
    {
        ac +=
        () =>
        {
            try
            {
                action();
            }
            catch (Exception e)
            {
                Debug.Log(e);
            }

        };


    }

}