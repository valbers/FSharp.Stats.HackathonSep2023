(*** hide ***)

(*** condition: prepare ***)
#r "../bin/FSharp.Stats/netstandard2.0/FSharp.Stats.dll"
#r "nuget: Plotly.NET, 2.0.0-beta3"

(*** condition: ipynb ***)
#if IPYNB
#r "nuget: Plotly.NET, 2.0.0-beta3"
#r "nuget: Plotly.NET.Interactive, 2.0.0-beta3"
#r "nuget: FSharp.Stats"
#endif // IPYNB

open Plotly.NET
open Plotly.NET.Axis
open Plotly.NET.StyleParam
(**
#Linear Algebra
*)

open FSharp.Stats
open FSharp.Stats.Algebra

// Consider a system of linear equation writen in matrix form
//   x1 +   x2 -   x3 =  4.
//   x1 - 2.x2 - 3.x3 = -6.
// 2.x1 + 3.x2 +   x3 =  7.
// -> AX = B

let A = 
    matrix [ [ 1.0;  1.0; -1.0 ]
             [ 1.0; -2.0; -3.0 ]
             [ 2.0;  3.0;  1.0 ] ]

let B = 
    matrix [ [  4.0; ]
             [ -6.0; ]
             [  7.0; ] ]



ServiceLocator.setEnvironmentPathVariable (__SOURCE_DIRECTORY__ + "/../../lib") //"D:/Source/FSharp.Stats/lib"

LinearAlgebra.Service()

LinearAlgebra.SVD A



// Let A = LU (LU - decomposition) and substitute into AX = B
// Solve LUX = B for X to solve the system.
// Let UX = Y 
// LY = B and UX = Y
// First solve LY = B for Y and then solve UX = Y for X.

let P,L,U = Algebra.LinearAlgebraManaged.LU A


open FSharp.Stats.Algebra
open FSharp.Stats.Algebra.LinearAlgebraManaged

//let SolveLinearSystemsByQR (A:matrix) (B:matrix) =
//    let (n,m) = A.Dimensions
//    //if n <> m then invalidArg "Matrix" "Matrix must be square." 
//    let q,r = QR A
//    let y = q.Transpose * B
//    (SolveTriangularLinearSystems r y true)


//let A = 
//    matrix [ [ 2.0; 1.0; 1.0 ]
//             [ 1.0; 3.0; 2.0 ]
//             [ 1.0; 0.0; 0.0 ] ]



//let B = 
//    matrix [ [ 4.0; ]
//             [ 5.0; ]
//             [ 6.0; ] ]

//// [  6.  15. -23.]
//SolveLinearSystems A B


