using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class Vector3Extensions
{
    public static Vector3 FindReflectedVectorBetween(this Vector3 from, Vector3 to)
    {
        if (from == null) throw new ArgumentException();
        if (to == null) throw new ArgumentException();
        return to - from;
    }
    public static Vector3 FindVectorBetween(this Vector3 from, Vector3 to)
    {
        if (from == null) throw new ArgumentException();
        if (to == null) throw new ArgumentException();
        return from - to;
    }
    public static Vector3 FindClosest<T>(this Vector3 from, List<T> source) where T : Component
    {
        if (source.Count <= 0) throw new ArgumentException();
        if (from == null) throw new ArgumentException();

        T closest = source.First();

        foreach (var another in source)
        {
            if (Vector3.Distance(another.transform.position, from) <
                Vector3.Distance(closest.transform.position, from))
                closest = another;
        } 
        return closest.transform.position;
    }
}
