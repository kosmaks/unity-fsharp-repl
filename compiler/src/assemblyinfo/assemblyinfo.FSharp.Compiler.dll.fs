#light
namespace Microsoft.FSharp
open System.Reflection
open System.Security

[<assembly:AssemblyDescription("FSharp.Compiler.dll")>]
[<assembly:AssemblyCompany("Microsoft Corporation")>]
[<assembly:AssemblyTitle("FSharp.Compiler.dll")>]
[<assembly:AssemblyCopyright("\169 Microsoft Corporation.  All rights reserved.")>]
[<assembly:AssemblyProduct("Microsoft\174 F#")>]
[<assembly:System.Runtime.CompilerServices.InternalsVisibleTo("fsc")>]
[<assembly:System.Runtime.CompilerServices.InternalsVisibleTo("fsi")>]
[<assembly:System.Runtime.CompilerServices.InternalsVisibleTo("FSI-ASSEMBLY")>]
[<assembly:System.Runtime.CompilerServices.InternalsVisibleTo("unity-fsharp-repl")>]
[<assembly:System.Runtime.CompilerServices.InternalsVisibleTo("FSharp.LanguageService")>]
[<assembly:System.Runtime.CompilerServices.InternalsVisibleTo("FSharp.ProjectSystem.Base")>]
[<assembly:System.Runtime.CompilerServices.InternalsVisibleTo("FSharp.ProjectSystem.FSharp")>]
[<assembly:System.Runtime.CompilerServices.InternalsVisibleTo("FSharp.ProjectSystem.PropertyPages")>]
[<assembly:System.Runtime.CompilerServices.InternalsVisibleTo("FSharp.Compiler.Interactive.Settings")>]
[<assembly:System.Runtime.CompilerServices.InternalsVisibleTo("FSharp.Compiler.Server.Shared")>]

// Note: internals visible to unit test DLLs in Retail (and all) builds.
[<assembly:System.Runtime.CompilerServices.InternalsVisibleTo("Test")>]
[<assembly:System.Runtime.CompilerServices.InternalsVisibleTo("Salsa")>]
[<assembly:System.Runtime.CompilerServices.InternalsVisibleTo("Unittests")>]
[<assembly:System.Runtime.CompilerServices.InternalsVisibleTo("SystematicUnitTests")>]
[<assembly:System.Runtime.CompilerServices.InternalsVisibleTo("fsc-proto")>]
[<assembly:SecurityTransparent()>]
do()
