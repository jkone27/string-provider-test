module SimpleStringProvider

open ProviderImplementation.ProvidedTypes
open Microsoft.FSharp.Core.CompilerServices

[<TypeProvider>]
type SingleStringTypeProvider (config : TypeProviderConfig) as this =
    inherit TypeProviderForNamespaces (config)

    let asm = System.Reflection.Assembly.GetExecutingAssembly()
    let ns = "SimpleStringProvider"
    let stringProvider = ProvidedTypeDefinition(asm, ns, "SingleStringTypeProvider", Some(typeof<obj>))

    // Define one static parameter with type name
    let parameter = ProvidedStaticParameter("TypeName", typeof<string>)
    do stringProvider.DefineStaticParameters([parameter], fun typeName args ->
    // Create the main type (this corresponds to `Provided`)    
    let resTy = ProvidedTypeDefinition(asm, ns, typeName, Some(typeof<obj>))

    // Add a nested type as a member using the name from the parameter
    let typeName = args.[0] :?> string
    ProvidedTypeDefinition(typeName, None)
    |> resTy.AddMember

    resTy )


[<assembly:TypeProviderAssembly>]
do ()