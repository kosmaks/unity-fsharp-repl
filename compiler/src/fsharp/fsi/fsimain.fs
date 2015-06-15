//----------------------------------------------------------------------------
// Copyright (c) 2002-2012 Microsoft Corporation. 
//
// This source code is subject to terms and conditions of the Apache License, Version 2.0. A 
// copy of the license can be found in the License.html file at the root of this distribution. 
// By using this source code in any fashion, you are agreeing to be bound 
// by the terms of the Apache License, Version 2.0.
//
// You must not remove this notice, or any other, from this software.
//----------------------------------------------------------------------------

module Microsoft.FSharp.Compiler.Interactive.Main

open System
open System.Threading
open System.IO
open Microsoft.FSharp.Compiler.Interactive
open Microsoft.FSharp.Compiler.Interactive.Shell
open Internal.Utilities

let private createStreams filename =
  if File.Exists(filename) then File.Delete(filename)
  let oStream = new FileStream(filename, FileMode.CreateNew, FileAccess.Write, FileShare.Read)
  let iStream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
  let sw      = new StreamWriter(oStream)
  let sr      = new StreamReader(iStream)
  sw.AutoFlush <- true
  (sw, sr)

let (stInputW, stInputR)   = createStreams "Temp/stdin.stream"
let (stOutputW, stOutputR) = createStreams "Temp/stdout.stream"
let (stErrorW, stErrorR)   = createStreams "Temp/stderr.stream"

let getMtFunction () = mtFunction
let resetMtFunction () = mtFunction <- None
let setMtResult r = mtResult <- Some r

let compilerThread (references : string []) =
  let references = references 
                   |> Array.map (fun x -> sprintf "-r:%s" x)
  let argv = Array.append [|
               ""
               "--noframework"
               "-r:References/mscorlib.dll"
               "-r:References/FSharp.Core.dll"
             |] references
  let fsi = FsiEvaluationSession (argv, stInputR, stOutputW, stErrorW)
  fsi.Run() 

let eval (code : string) = 
  stInputW.WriteLine(code)

let getoutput () = stOutputR.ReadToEnd()
let geterror () = stErrorR.ReadToEnd()

#nowarn "55"

// Mark the main thread as STAThread since it is a GUI thread
[<EntryPoint>]
[<STAThread()>]    
let MainMain argv = 
    ignore argv
    let argv = System.Environment.GetCommandLineArgs()
    printfn "%A" argv

    // When VFSI is running, set the input/output encoding to UTF8.
    // Otherwise, unicode gets lost during redirection.
    // It is required only under Net4.5 or above (with unicode console feature).
    if FSharpEnvironment.IsRunningOnNetFx45OrAbove && 
        argv |> Array.exists (fun x -> x.Contains "fsi-server") then
        Console.InputEncoding <- System.Text.Encoding.UTF8 
        Console.OutputEncoding <- System.Text.Encoding.UTF8

    let fsi = FsiEvaluationSession (argv, Console.In, Console.Out, Console.Error)
    fsi.Run() 

    0
