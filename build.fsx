#r @"packages/FAKE/tools/FakeLib.dll"
open Fake

let version = "0.0.1"

let libBuildDir = "bin/release/unity/Editor"
let clientBuildDir = "bin/release/client/"

let libAppReference = !! "unity-fsharp-repl.fsproj"
let clientAppReference = !! "unity-fsharp-repl-client.fsproj"

Target "Clean" (fun _ ->
  CleanDirs [libBuildDir; clientBuildDir]
)

Target "BuildLib" (fun _ ->
    MSBuildRelease libBuildDir "Build" libAppReference
      |> Log "LibBuild-Output: "
)

Target "BuildClient" (fun _ ->
    MSBuildRelease clientBuildDir "Build" clientAppReference
      |> Log "ClientBuild-Output: "
)

Target "All" DoNothing

"Clean"
  ==> "BuildLib"
  ==> "BuildClient"
  ==> "All"

RunTargetOrDefault "All"
