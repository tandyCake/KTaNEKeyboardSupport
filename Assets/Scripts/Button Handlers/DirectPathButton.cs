﻿using System;
using UnityEngine;

/// <summary>
/// Finds a button by using a series of Transform names.
/// </summary>
public class DirectPathButton : ButtonInfo {

    /// <summary>
    /// A series of Transform names to search down.
    /// </summary>
    private readonly string[] _path;

    /// <summary>
    /// Creates a new DirectPathButton with the given path (starting from the children of the parent selectable).
    /// </summary>
    /// <exception cref="ArgumentException">The path length is equal to zero.</exception>
    public DirectPathButton(params string[] path)
    {
        if (path.Length == 0)
            throw new ArgumentException("Path length cannot be zero.");
        _path = path;
    }
    public override Transform GetTransform(Transform root)
    {
        Transform target = root;
        foreach (string pathItem in _path)
            target = GetChild(target, pathItem);
        return target;
    }
}