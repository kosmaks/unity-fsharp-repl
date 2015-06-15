=== Unity F# REPL ===

Requirements:
* Mono >3.0
* F# binaries installed
* Tested on Unity 5.0.2f, but probably would work with older versions

== Description ==

*This is pre-pre-pre-alpha version :) Don''t use it for any serious project so far.*

This library integrates F# interactive repl into Unity environment.
It uses modified F# compiler libraries (.NET 2.0) for embedding.

== How to use ==

Build tested on OS X.

* Build
```
$ ./build.sh
```
* Copy contents of `bin/release/unity` to `Assets` directory
* You'll also need some binaries copied to `<unity-project-path>/References`.
  I'll figure out way to ship them later. For now you can take some form nuget
  and installed binaries. Make sure you have correct versions!
  * FSharp.Core.dll (net20)
  * mscorlib.dll (net20)
  * UnityEngine.dll
  * UnityEditor.dll
* Run client from unity project root path