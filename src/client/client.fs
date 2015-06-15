open System
open System.IO
open System.Threading

let createStreams filename =
  let oStream = new FileStream(filename, FileMode.Append, FileAccess.Write, FileShare.Read)
  let iStream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
  let sw      = new StreamWriter(oStream)
  let sr      = new StreamReader(iStream)
  sw.AutoFlush <- true
  (sw, sr)

let (stdinw, stdinr)   = createStreams "Temp/stdin.stream"
let (stdoutw, stdoutr) = createStreams "Temp/stdout.stream"
let (stderrw, stderrr) = createStreams "Temp/stderr.stream"

let readerThread (reader : TextReader) () =
  try
    while true do
      reader.ReadToEnd() |> printf "%s"
      Thread.Sleep(1)
  with
  | :? ThreadAbortException -> ()

let rec readLoop () =
  Console.ReadLine()
  |> stdinw.WriteLine
  readLoop()

[<EntryPoint>]
let main argv =
  stdoutr.ReadToEnd() |> ignore
  printf "Unity FSharp REPL"
  printf "> "
  (new Thread(readerThread stdoutr)).Start()
  (new Thread(readerThread stderrr)).Start()
  readLoop()
  0
