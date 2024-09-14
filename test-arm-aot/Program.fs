//dotnet publish .\test-arm-aot\test-arm-aot.fsproj -c Release -f net9.0 --tl:off --verbosity n --sc --runtime linux-musl-arm  /property:PublishTrimmed=True /property:IncludeNativeLibrariesForSelfExtract=True /property:DebugType=None /property:DebugSymbols=False /property:PublishAot=True /p:StripSymbols=True
//dotnet publish .\test-arm-aot\test-arm-aot.fsproj -c Release -f net9.0 --tl:off --verbosity n --sc --runtime linux-arm  /property:PublishTrimmed=True /property:IncludeNativeLibrariesForSelfExtract=True /property:DebugType=None /property:DebugSymbols=False /property:PublishAot=False /property:PublishSingleFile=True /p:StripSymbols=True
open System
open FSharpPlus

[<EntryPoint>]
let main _argv =
    printfn "Running on .NET %s" (System.Environment.Version.ToString())

    if IO.File.Exists "/proc/cpuinfo" then
        "/proc/cpuinfo"
        |> IO.File.ReadAllText
        |> String.split [ "\n" ]
        |> Seq.filter (fun x -> x.Contains("model name"))
        |> Seq.head
        |> String.split [ ":" ]
        |> Seq.item 1
        |> printfn "CPU: %s"
    else
        printfn "Hello World from F#!"

    0 // return an integer exit code
