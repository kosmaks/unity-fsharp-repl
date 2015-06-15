module UnityFSharpRepl.REPL

open Microsoft.FSharp.Compiler.Interactive
open UnityEngine
open System
open System.Reflection
open System.Threading
open System.Collections.Generic

let eval code = Main.eval code

let compiler assembly () =
  eval "open UnityEngine;;\n"
  Main.compilerThread [|"References/UnityEngine.dll"; assembly |]

let run assembly = 
  let thread = new Thread(compiler assembly)
  thread.Start()

// FIXME dirty hack to run in main thread
let update () =
  match Main.getMtFunction() with
  | Some fn -> fn() |> Main.setMtResult
  | None -> ()
