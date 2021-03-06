﻿using System;
using UnityEngine;

public static class JsonHelper {

    //Fuente: https://answers.unity.com/users/974079/matchsun.html
    public static T[] getJsonArray<T>(string json)
    {
        string newJson = "{ \"array\": " + json + "}";
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>> (newJson);
        return wrapper.array;
    }
    
    public static string arrayToJson<T>(T[] array)
    {
        Wrapper<T> wrapper = new Wrapper<T> ();
        wrapper.array = array;
        return JsonUtility.ToJson (wrapper);
    }
 
    [Serializable]
    private class Wrapper<T>
    {
        public T[] array;
    }
}