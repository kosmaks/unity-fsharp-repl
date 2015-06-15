using UnityEditor;
using UnityEngine;
using System;
using System.Reflection;
using System.Collections.Generic;
using UnityFSharpRepl;

[InitializeOnLoad]
public class REPLHelper {
    static readonly Queue<Action<object>> _queue = new Queue<Action<object>>();

    static REPLHelper() {
        var assembly = Assembly.GetExecutingAssembly().Location;
        REPL.run(assembly);
        EditorApplication.update -= REPL.update;
        EditorApplication.update += REPL.update;
    }

    static void Update() {
        while (_queue.Count > 0) {
            _queue.Dequeue()(null);
        }
    }

    public static void RunOnMainThread(Action<object> action) {
        _queue.Enqueue(action);
    }
}
