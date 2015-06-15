using UnityEditor;
using UnityEngine;
using System;
using System.Reflection;
using System.Collections.Generic;
using UnityFSharpRepl;

[InitializeOnLoad]
public class REPLHelper {
    static REPLHelper() {
        var assembly = Assembly.GetExecutingAssembly().Location;
        REPL.run(assembly);
        EditorApplication.update -= REPL.update;
        EditorApplication.update += REPL.update;
    }
}
