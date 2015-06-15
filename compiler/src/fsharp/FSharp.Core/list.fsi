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

namespace Microsoft.FSharp.Collections

    open System
    open System.Collections.Generic
    open Microsoft.FSharp.Core
    open Microsoft.FSharp.Collections

    /// <summary>Basic operations on lists.</summary>
    [<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
    [<RequireQualifiedAccess>]
    module List = 

        /// <summary>Returns a new list that contains the elements of the first list
        /// followed by elements of the second.</summary>
        /// <param name="list1">The first input list.</param>
        /// <param name="list2">The second input list.</param>
        /// <returns>The resulting list.</returns>
        [<CompiledName("Append")>]
        val append: list1:'T list -> list2:'T list -> 'T list

        /// <summary>Returns the average of the elements in the list.</summary>
        ///
        /// <remarks>Raises <c>System.ArgumentException</c> if <c>list</c> is empty.</remarks>
        /// <param name="list">The input list.</param>
        /// <exception cref="System.ArgumentException">Thrown when the list is empty.</exception>
        /// <returns>The resulting average.</returns>
        [<CompiledName("Average")>]
        val inline average   : list:^T list -> ^T    
                                   when ^T : (static member ( + ) : ^T * ^T -> ^T) 
                                   and  ^T : (static member DivideByInt : ^T*int -> ^T) 
                                   and  ^T : (static member Zero : ^T)

        /// <summary>Returns the average of the elements generated by applying the function to each element of the list.</summary>
        ///
        /// <remarks>Raises <c>System.ArgumentException</c> if <c>list</c> is empty.</remarks>
        /// <param name="projection">The function to transform the list elements into the type to be averaged.</param>
        /// <param name="list">The input list.</param>
        /// <exception cref="System.ArgumentException">Thrown when the list is empty.</exception>
        /// <returns>The resulting average.</returns>
        [<CompiledName("AverageBy")>]
        val inline averageBy   : projection:('T -> ^U) -> list:'T list  -> ^U    
                                   when ^U : (static member ( + ) : ^U * ^U -> ^U) 
                                   and  ^U : (static member DivideByInt : ^U*int -> ^U) 
                                   and  ^U : (static member Zero : ^U)

        /// <summary>Applies the given function to each element of the list. Returns
        /// the list comprised of the results <c>x</c> for each element where
        /// the function returns Some(x)</summary>
        /// <param name="chooser">The function to generate options from the elements.</param>
        /// <param name="list">The input list.</param>
        /// <returns>The list comprising the values selected from the chooser function.</returns>
        [<CompiledName("Choose")>]
        val choose: chooser:('T -> 'U option) -> list:'T list -> 'U list

        /// <summary>For each element of the list, applies the given function. Concatenates all the results and return the combined list.</summary>
        /// <param name="mapping">The function to transform each input element into a sublist to be concatenated.</param>
        /// <param name="list">The input list.</param>
        /// <returns>The concatenation of the transformed sublists.</returns>
        [<CompiledName("Collect")>]
        val collect: mapping:('T -> 'U list) -> list:'T list -> 'U list

        /// <summary>Returns a new list that contains the elements of each the lists in order.</summary>
        /// <param name="lists">The input sequence of lists.</param>
        /// <returns>The resulting concatenated list.</returns>
        [<CompiledName("Concat")>]
        val concat: lists:seq<'T list> -> 'T list

        /// <summary>Returns an empty list of the given type.</summary>
        [<GeneralizableValue>]
        [<CompiledName("Empty")>]
        val empty<'T> : 'T list

        /// <summary>Tests if any element of the list satisfies the given predicate.</summary>
        ///
        /// <remarks>The predicate is applied to the elements of the input list. If any application 
        /// returns true then the overall result is true and no further elements are tested. 
        /// Otherwise, false is returned.</remarks>
        /// <param name="predicate">The function to test the input elements.</param>
        /// <param name="list">The input list.</param>
        /// <returns>True if any element satisfies the predicate.</returns>
        [<CompiledName("Exists")>]
        val exists: predicate:('T -> bool) -> list:'T list -> bool

        /// <summary>Tests if any pair of corresponding elements of the lists satisfies the given predicate.</summary>
        ///
        /// <remarks>The predicate is applied to matching elements in the two collections up to the lesser of the 
        /// two lengths of the collections. If any application returns true then the overall result is 
        /// true and no further elements are tested. Otherwise, if one collections is longer 
        /// than the other then the <c>System.ArgumentException</c> exception is raised. 
        /// Otherwise, false is returned.</remarks>
        /// <param name="predicate">The function to test the input elements.</param>
        /// <param name="list1">The first input list.</param>
        /// <param name="list2">The second input list.</param>
        /// <exception cref="System.ArgumentException">Thrown when the input lists differ in length.</exception>
        /// <returns>True if any pair of elements satisfy the predicate.</returns>
        [<CompiledName("Exists2")>]
        val exists2: predicate:('T1 -> 'T2 -> bool) -> list1:'T1 list -> list2:'T2 list -> bool

        /// <summary>Returns the first element for which the given function returns <c>true</c>.
        /// Raises <c>KeyNotFoundException</c> if no such element exists.</summary>
        /// <param name="predicate">The function to test the input elements.</param>
        /// <param name="list">The input list.</param>
        /// <exception cref="System.Collections.Generic.KeyNotFoundException">Thrown if the predicate evaluates to false for
        /// all the elements of the list.</exception>
        /// <returns>The first element that satisfies the predicate.</returns>
        [<CompiledName("Find")>]
        val find: predicate:('T -> bool) -> list:'T list -> 'T

        /// <summary>Returns the index of the first element in the list
        /// that satisfies the given predicate.
        /// Raises <c>KeyNotFoundException</c> if no such element exists.</summary>
        /// <param name="predicate">The function to test the input elements.</param>
        /// <param name="list">The input list.</param>
        /// <exception cref="System.ArgumentException">Thrown if the predicate evaluates to false for all the
        /// elements of the list.</exception>
        /// <returns>The index of the first element that satisfies the predicate.</returns>
        [<CompiledName("FindIndex")>]
        val findIndex: predicate:('T -> bool) -> list:'T list -> int

        /// <summary>Returns a new collection containing only the elements of the collection
        /// for which the given predicate returns "true"</summary>
        /// <param name="predicate">The function to test the input elements.</param>
        /// <param name="list">The input list.</param>
        /// <returns>A list containing only the elements that satisfy the predicate.</returns>
        [<CompiledName("Filter")>]
        val filter: predicate:('T -> bool) -> list:'T list -> 'T list

        /// <summary>Applies a function to each element of the collection, threading an accumulator argument
        /// through the computation. Take the second argument, and apply the function to it
        /// and the first element of the list. Then feed this result into the function along
        /// with the second element and so on. Return the final result.
        /// If the input function is <c>f</c> and the elements are <c>i0...iN</c> then 
        /// computes <c>f (... (f s i0) i1 ...) iN</c>.</summary>
        /// <param name="folder">The function to update the state given the input elements.</param>
        /// <param name="state">The initial state.</param>
        /// <param name="list">The input list.</param>
        /// <returns>The final state value.</returns>
        [<CompiledName("Fold")>]
        val fold<'T,'State> : folder:('State -> 'T -> 'State) -> state:'State -> list:'T list -> 'State

        /// <summary>Applies a function to corresponding elements of two collections, threading an accumulator argument
        /// through the computation. The collections must have identical sizes.
        /// If the input function is <c>f</c> and the elements are <c>i0...iN</c> and <c>j0...jN</c>
        /// then computes <c>f (... (f s i0 j0)...) iN jN</c>.</summary>
        /// <param name="folder">The function to update the state given the input elements.</param>
        /// <param name="state">The initial state.</param>
        /// <param name="list1">The first input list.</param>
        /// <param name="list2">The second input list.</param>
        /// <returns>The final state value.</returns>
        [<CompiledName("Fold2")>]
        val fold2<'T1,'T2,'State> : folder:('State -> 'T1 -> 'T2 -> 'State) -> state:'State -> list1:'T1 list -> list2:'T2 list -> 'State

        /// <summary>Applies a function to each element of the collection, threading an accumulator argument
        /// through the computation. If the input function is <c>f</c> and the elements are <c>i0...iN</c> then 
        /// computes <c>f i0 (...(f iN s))</c>.</summary>
        /// <param name="folder">The function to update the state given the input elements.</param>
        /// <param name="list">The input list.</param>
        /// <param name="state">The initial state.</param>
        /// <returns>The final state value.</returns>
        [<CompiledName("FoldBack")>]
        val foldBack<'T,'State> : folder:('T -> 'State -> 'State) -> list:'T list -> state:'State -> 'State

        /// <summary>Applies a function to corresponding elements of two collections, threading an accumulator argument
        /// through the computation. The collections must have identical sizes.
        /// If the input function is <c>f</c> and the elements are <c>i0...iN</c> and <c>j0...jN</c>
        /// then computes <c>f i0 j0 (...(f iN jN s))</c>.</summary>
        /// <param name="folder">The function to update the state given the input elements.</param>
        /// <param name="list1">The first input list.</param>
        /// <param name="list2">The second input list.</param>
        /// <param name="state">The initial state.</param>
        /// <returns>The final state value.</returns>
        [<CompiledName("FoldBack2")>]
        val foldBack2<'T1,'T2,'State> : folder:('T1 -> 'T2 -> 'State -> 'State) -> list1:'T1 list -> list2:'T2 list -> state:'State -> 'State

        /// <summary>Tests if all elements of the collection satisfy the given predicate.</summary>
        ///
        /// <remarks>The predicate is applied to the elements of the input list. If any application 
        /// returns false then the overall result is false and no further elements are tested. 
        /// Otherwise, true is returned.</remarks>
        /// <param name="predicate">The function to test the input elements.</param>
        /// <param name="list">The input list.</param>
        /// <returns>True if all of the elements satisfy the predicate.</returns>
        [<CompiledName("ForAll")>]
        val forall: predicate:('T -> bool) -> list:'T list -> bool

        /// <summary>Tests if all corresponding elements of the collection satisfy the given predicate pairwise.</summary>
        ///
        /// <remarks>The predicate is applied to matching elements in the two collections up to the lesser of the 
        /// two lengths of the collections. If any application returns false then the overall result is 
        /// false and no further elements are tested. Otherwise, if one collection is longer 
        /// than the other then the <c>System.ArgumentException</c> exception is raised. 
        /// Otherwise, true is returned.</remarks>
        /// <param name="predicate">The function to test the input elements.</param>
        /// <param name="list1">The first input list.</param>
        /// <param name="list2">The second input list.</param>
        /// <exception cref="System.ArgumentException">Thrown when the input lists differ in length.</exception>
        /// <returns>True if all of the pairs of elements satisfy the predicate.</returns>
        [<CompiledName("ForAll2")>]
        val forall2: predicate:('T1 -> 'T2 -> bool) -> list1:'T1 list -> list2:'T2 list -> bool

        /// <summary>Returns the first element of the list.</summary>
        ///
        /// <param name="list">The input list.</param>
        /// <exception cref="System.ArgumentException">Thrown when the list is empty.</exception>
        /// <returns>The first element of the list.</returns>
        [<CompiledName("Head")>]
        val head: list:'T list -> 'T

        /// <summary>Creates a list by calling the given generator on each index.</summary>
        /// <param name="length">The length of the list to generate.</param>
        /// <param name="initializer">The function to generate an element from an index.</param>
        /// <returns>The list of generated elements.</returns>
        [<CompiledName("Initialize")>]
        val init: length:int -> initializer:(int -> 'T) -> 'T list

        /// <summary>Returns true if the list contains no elements, false otherwise.</summary>
        /// <param name="list">The input list.</param>
        /// <returns>True if the list is empty.</returns>
        [<CompiledName("IsEmpty")>]
        val isEmpty: list:'T list -> bool

        /// <summary>Applies the given function to each element of the collection.</summary>
        /// <param name="action">The function to apply to elements from the input list.</param>
        /// <param name="list">The input list.</param>
        [<CompiledName("Iterate")>]
        val iter: action:('T -> unit) -> list:'T list -> unit

        /// <summary>Applies the given function to two collections simultaneously. The
        /// collections must have identical size.</summary>
        /// <param name="action">The function to apply to pairs of elements from the input lists.</param>
        /// <param name="list1">The first input list.</param>
        /// <param name="list2">The second input list.</param>
        [<CompiledName("Iterate2")>]
        val iter2: action:('T1 -> 'T2 -> unit) -> list1:'T1 list -> list2:'T2 list -> unit

        /// <summary>Applies the given function to each element of the collection. The integer passed to the
        /// function indicates the index of element.</summary>
        /// <param name="action">The function to apply to the elements of the list along with their index.</param>
        /// <param name="list">The input list.</param>
        [<CompiledName("IterateIndexed")>]
        val iteri: action:(int -> 'T -> unit) -> list:'T list -> unit

        /// <summary>Applies the given function to two collections simultaneously. The
        /// collections must have identical size. The integer passed to the
        /// function indicates the index of element.</summary>
        /// <param name="action">The function to apply to a pair of elements from the input lists along with their index.</param>
        /// <param name="list1">The first input list.</param>
        /// <param name="list2">The second input list.</param>
        [<CompiledName("IterateIndexed2")>]
        val iteri2: action:(int -> 'T1 -> 'T2 -> unit) -> list1:'T1 list -> list2:'T2 list -> unit

        /// <summary>Returns the length of the list.</summary>
        /// <param name="list">The input list.</param>
        /// <returns>The length of the list.</returns>
        [<CompiledName("Length")>]
        val length: list:'T list -> int

        /// <summary>Builds a new collection whose elements are the results of applying the given function
        /// to each of the elements of the collection.</summary>
        /// <param name="mapping">The function to transform elements from the input list.</param>
        /// <param name="list">The input list.</param>
        /// <returns>The list of transformed elements.</returns>
        [<CompiledName("Map")>]
        val map: mapping:('T -> 'U) -> list:'T list -> 'U list

        /// <summary>Builds a new collection whose elements are the results of applying the given function
        /// to the corresponding elements of the two collections pairwise.</summary>
        /// <param name="mapping">The function to transform pairs of elements from the input lists.</param>
        /// <param name="list1">The first input list.</param>
        /// <param name="list2">The second input list.</param>
        /// <returns>The list of transformed elements.</returns>
        [<CompiledName("Map2")>]
        val map2: mapping:('T1 -> 'T2 -> 'U) -> list1:'T1 list -> list2:'T2 list -> 'U list

        /// <summary>Builds a new collection whose elements are the results of applying the given function
        /// to the corresponding elements of the three collections simultaneously.</summary>
        /// <param name="mapping">The function to transform triples of elements from the input lists.</param>
        /// <param name="list1">The first input list.</param>
        /// <param name="list2">The second input list.</param>
        /// <param name="list3">The third input list.</param>
        /// <returns>The list of transformed elements.</returns>
        [<CompiledName("Map3")>]
        val map3: mapping:('T1 -> 'T2 -> 'T3 -> 'U) -> list1:'T1 list -> list2:'T2 list -> list3:'T3 list -> 'U list

        /// <summary>Builds a new collection whose elements are the results of applying the given function
        /// to each of the elements of the collection. The integer index passed to the
        /// function indicates the index (from 0) of element being transformed.</summary>
        /// <param name="mapping">The function to transform elements and their indices.</param>
        /// <param name="list">The input list.</param>
        /// <returns>The list of transformed elements.</returns>
        [<CompiledName("MapIndexed")>]
        val mapi: mapping:(int -> 'T -> 'U) -> list:'T list -> 'U list

        /// <summary>Like mapi, but mapping corresponding elements from two lists of equal length.</summary>
        /// <param name="mapping">The function to transform pairs of elements from the two lists and their index.</param>
        /// <param name="list1">The first input list.</param>
        /// <param name="list2">The second input list.</param>
        /// <returns>The list of transformed elements.</returns>
        [<CompiledName("MapIndexed2")>]
        val mapi2: mapping:(int -> 'T1 -> 'T2 -> 'U) -> list1:'T1 list -> list2:'T2 list -> 'U list

        /// <summary>Return the greatest of all elements of the list, compared via Operators.max.</summary>
        ///
        /// <remarks>Raises <c>System.ArgumentException</c> if <c>list</c> is empty</remarks>
        /// <param name="list">The input list.</param>
        /// <exception cref="System.ArgumentException">Thrown when the list is empty.</exception>
        /// <returns>The maximum element.</returns>
        [<CompiledName("Max")>]
        val inline max     : list:'T list -> 'T when 'T : comparison 

        /// <summary>Returns the greatest of all elements of the list, compared via Operators.max on the function result.</summary>
        ///
        /// <remarks>Raises <c>System.ArgumentException</c> if <c>list</c> is empty.</remarks>
        /// <param name="projection">The function to transform the list elements into the type to be compared.</param>
        /// <param name="list">The input list.</param>
        /// <exception cref="System.ArgumentException">Thrown when the list is empty.</exception>
        /// <returns>The maximum element.</returns>
        [<CompiledName("MaxBy")>]
        val inline maxBy   : projection:('T -> 'U) -> list:'T list -> 'T when 'U : comparison 

        /// <summary>Returns the lowest of all elements of the list, compared via Operators.min.</summary>
        ///
        /// <remarks>Raises <c>System.ArgumentException</c> if <c>list</c> is empty</remarks>
        /// <param name="list">The input list.</param>
        /// <exception cref="System.ArgumentException">Thrown when the list is empty.</exception>
        /// <returns>The minimum value.</returns>
        [<CompiledName("Min")>]
        val inline min     : list:'T list -> 'T when 'T : comparison 

        /// <summary>Returns the lowest of all elements of the list, compared via Operators.min on the function result</summary>
        ///
        /// <remarks>Raises <c>System.ArgumentException</c> if <c>list</c> is empty.</remarks>
        /// <param name="projection">The function to transform list elements into the type to be compared.</param>
        /// <param name="list">The input list.</param>
        /// <exception cref="System.ArgumentException">Thrown when the list is empty.</exception>
        /// <returns>The minimum value.</returns>
        [<CompiledName("MinBy")>]
        val inline minBy   : projection:('T -> 'U) -> list:'T list -> 'T when 'U : comparison 

        /// <summary>Indexes into the list. The first element has index 0.</summary>
        /// <param name="list">The input list.</param>
        /// <param name="index">The index to retrieve.</param>
        /// <returns>The value at the given index.</returns>
        [<CompiledName("Get")>]
        val nth: list:'T list -> index:int -> 'T

        /// <summary>Builds a list from the given array.</summary>
        /// <param name="array">The input array.</param>
        /// <returns>The list of elements from the array.</returns>
        [<CompiledName("OfArray")>]
        val ofArray : array:'T[] -> 'T list

        /// <summary>Builds a new list from the given enumerable object.</summary>
        /// <param name="source">The input sequence.</param>
        /// <returns>The list of elements from the sequence.</returns>
        [<CompiledName("OfSeq")>]
        val ofSeq: source:seq<'T> -> 'T list

        /// <summary>Splits the collection into two collections, containing the 
        /// elements for which the given predicate returns <c>true</c> and <c>false</c>
        /// respectively. Element order is preserved in both of the created lists.</summary>
        /// <param name="predicate">The function to test the input elements.</param>
        /// <param name="list">The input list.</param>
        /// <returns>A list containing the elements for which the predicate evaluated to false and a list
        /// containing the elements for which the predicate evaluated to true.</returns>
        [<CompiledName("Partition")>]
        val partition: predicate:('T -> bool) -> list:'T list -> ('T list * 'T list)

        /// <summary>Applies the given function to successive elements, returning the first
        /// result where function returns <c>Some(x)</c> for some x. If no such
        /// element exists then raise <c>System.Collections.Generic.KeyNotFoundException</c></summary>
        /// <param name="chooser">The function to generate options from the elements.</param>
        /// <param name="list">The input list.</param>
        /// <exception cref="System.Collections.Generic.KeyNotFoundException">Thrown when the list is empty.</exception>
        /// <returns>The first resulting value.</returns>
        [<CompiledName("Pick")>]
        val pick: chooser:('T -> 'U option) -> list:'T list -> 'U

        /// <summary>Returns a list with all elements permuted according to the
        /// specified permutation.</summary>
        /// <param name="indexMap">The function to map input indices to output indices.</param>
        /// <param name="list">The input list.</param>
        /// <returns>The permutated list.</returns>
        [<CompiledName("Permute")>]
        val permute : indexMap:(int -> int) -> list:'T list -> 'T list

        /// <summary>Apply a function to each element of the collection, threading an accumulator argument
        /// through the computation. Apply the function to the first two elements of the list.
        /// Then feed this result into the function along with the third element and so on. 
        /// Return the final result. If the input function is <c>f</c> and the elements are <c>i0...iN</c> then computes 
        /// <c>f (... (f i0 i1) i2 ...) iN</c>.</summary>
        ///
        /// <remarks>Raises <c>System.ArgumentException</c> if <c>list</c> is empty</remarks>
        /// <param name="reduction">The function to reduce two list elements to a single element.</param>
        /// <param name="list">The input list.</param>
        /// <exception cref="System.ArgumentException">Thrown when the list is empty.</exception>
        /// <returns>The final reduced value.</returns>
        [<CompiledName("Reduce")>]
        val reduce: reduction:('T -> 'T -> 'T) -> list:'T list -> 'T

        /// <summary>Applies a function to each element of the collection, threading an accumulator argument
        /// through the computation. If the input function is <c>f</c> and the elements are <c>i0...iN</c> then computes 
        /// <c>f i0 (...(f iN-1 iN))</c>.</summary>
        ///
        /// <remarks>Raises <c>System.ArgumentException</c> if <c>list</c> is empty</remarks>
        /// <param name="reduction">The function to reduce two list elements to a single element.</param>
        /// <param name="list">The input list.</param>
        /// <exception cref="System.ArgumentException">Thrown when the list is empty.</exception>
        /// <returns>The final reduced value.</returns>
        [<CompiledName("ReduceBack")>]
        val reduceBack: reduction:('T -> 'T -> 'T) -> list:'T list -> 'T

        /// <summary>Creates a list by calling the given generator on each index.</summary>
        /// <param name="count">The number of elements to replicate.</param>
        /// <param name="initial">The value to replicate</param>
        /// <returns>The generated list.</returns>
        [<CompiledName("Replicate")>]
        val replicate: count:int -> initial:'T -> 'T list

        /// <summary>Returns a new list with the elements in reverse order.</summary>
        /// <param name="list">The input list.</param>
        /// <returns>The reversed list.</returns>
        [<CompiledName("Reverse")>]
        val rev: list:'T list -> 'T list

        /// <summary>Applies a function to each element of the collection, threading an accumulator argument
        /// through the computation. Take the second argument, and apply the function to it
        /// and the first element of the list. Then feed this result into the function along
        /// with the second element and so on. Returns the list of intermediate results and the final result.</summary>
        /// <param name="folder">The function to update the state given the input elements.</param>
        /// <param name="state">The initial state.</param>
        /// <param name="list">The input list.</param>
        /// <returns>The list of states.</returns>
        [<CompiledName("Scan")>]
        val scan<'T,'State>  : folder:('State -> 'T -> 'State) -> state:'State -> list:'T list -> 'State list

        /// <summary>Like <c>foldBack</c>, but returns both the intermediary and final results</summary>
        /// <param name="folder">The function to update the state given the input elements.</param>
        /// <param name="list">The input list.</param>
        /// <param name="state">The initial state.</param>
        /// <returns>The list of states.</returns>
        [<CompiledName("ScanBack")>]
        val scanBack<'T,'State> : folder:('T -> 'State -> 'State) -> list:'T list -> state:'State -> 'State list

        /// <summary>Sorts the given list using the given comparison function.</summary>
        ///
        /// <remarks>This is a stable sort, i.e. the original order of equal elements is preserved.</remarks>
        /// <param name="comparer">The function to compare the list elements.</param>
        /// <param name="list">The input list.</param>
        /// <returns>The sorted list.</returns>
        [<CompiledName("SortWith")>]
        val sortWith: comparer:('T -> 'T -> int) -> list:'T list -> 'T list 

        /// <summary>Sorts the given list using keys given by the given projection. Keys are compared using Operators.compare.</summary>
        ///
        /// <remarks>This is a stable sort, i.e. the original order of equal elements is preserved.</remarks>
        /// <param name="projection">The function to transform the list elements into the type to be compared.</param>
        /// <param name="list">The input list.</param>
        /// <returns>The sorted list.</returns>
        [<CompiledName("SortBy")>]
        val sortBy: projection:('T -> 'Key) -> list:'T list -> 'T list when 'Key : comparison

        /// <summary>Sorts the given list using Operators.compare.</summary>
        ///
        /// <remarks>This is a stable sort, i.e. the original order of equal elements is preserved.</remarks>
        /// <param name="list">The input list.</param>
        /// <returns>The sorted list.</returns>
        [<CompiledName("Sort")>]
        val sort: list:'T list -> 'T list when 'T : comparison

        /// <summary>Returns the sum of the elements in the list.</summary>
        /// <param name="list">The input list.</param>
        /// <returns>The resulting sum.</returns>
        [<CompiledName("Sum")>]
        val inline sum   : list:^T list -> ^T 
                                   when ^T : (static member ( + ) : ^T * ^T -> ^T) 
                                   and  ^T : (static member Zero : ^T)

        /// <summary>Returns the sum of the results generated by applying the function to each element of the list.</summary>
        /// <param name="projection">The function to transform the list elements into the type to be summed.</param>
        /// <param name="list">The input list.</param>
        /// <returns>The resulting sum.</returns>
        [<CompiledName("SumBy")>]
        val inline sumBy : projection:('T -> ^U) -> list:'T list -> ^U 
                                   when ^U : (static member ( + ) : ^U * ^U -> ^U) 
                                   and  ^U : (static member Zero : ^U)

        /// <summary>Returns the list after removing the first element.</summary>
        ///
        /// <param name="list">The input list.</param>
        /// <exception cref="System.ArgumentException">Thrown when the list is empty.</exception>
        /// <returns>The list after removing the first element.</returns>
        [<CompiledName("Tail")>]
        val tail: list:'T list -> 'T list

        /// <summary>Builds an array from the given list.</summary>
        /// <param name="list">The input list.</param>
        /// <returns>The array containing the elements of the list.</returns>
        [<CompiledName("ToArray")>]
        val toArray: list:'T list -> 'T[]

        /// <summary>Views the given list as a sequence.</summary>
        /// <param name="list">The input list.</param>
        /// <returns>The sequence of elements in the list.</returns>
        [<CompiledName("ToSeq")>]
        val toSeq: list:'T list -> seq<'T>

        /// <summary>Applies the given function to successive elements, returning <c>Some(x)</c> the first
        /// result where function returns <c>Some(x)</c> for some x. If no such element 
        /// exists then return <c>None</c>.</summary>
        /// <param name="chooser">The function to generate options from the elements.</param>
        /// <param name="list">The input list.</param>
        /// <returns>The first resulting value or None.</returns>
        [<CompiledName("TryPick")>]
        val tryPick: chooser:('T -> 'U option) -> list:'T list -> 'U option

        /// <summary>Returns the first element for which the given function returns <c>true.</c>.
        /// Return <c>None</c> if no such element exists.</summary>
        /// <param name="predicate">The function to test the input elements.</param>
        /// <param name="list">The input list.</param>
        /// <returns>The first element for which the predicate returns true, or None if
        /// every element evaluates to false.</returns>
        [<CompiledName("TryFind")>]
        val tryFind: predicate:('T -> bool) -> list:'T list -> 'T option

        /// <summary>Returns the index of the first element in the list
        /// that satisfies the given predicate.
        /// Return <c>None</c> if no such element exists.</summary>
        /// <param name="predicate">The function to test the input elements.</param>
        /// <param name="list">The input list.</param>
        /// <returns>The index of the first element for which the predicate returns true, or None if
        /// every element evaluates to false.</returns>
        [<CompiledName("TryFindIndex")>]
        val tryFindIndex: predicate:('T -> bool) -> list:'T list -> int option

        /// <summary>Splits a list of pairs into two lists.</summary>
        /// <param name="list">The input list.</param>
        /// <returns>Two lists of split elements.</returns>
        [<CompiledName("Unzip")>]
        val unzip: list:('T1 * 'T2) list -> ('T1 list * 'T2 list)

        /// <summary>Splits a list of triples into three lists.</summary>
        /// <param name="list">The input list.</param>
        /// <returns>Three lists of split elements.</returns>
        [<CompiledName("Unzip3")>]
        val unzip3: list:('T1 * 'T2 * 'T3) list -> ('T1 list * 'T2 list * 'T3 list)

        /// <summary>Combines the two lists into a list of pairs. The two lists must have equal lengths.</summary>
        /// <param name="list1">The first input list.</param>
        /// <param name="list2">The second input list.</param>
        /// <returns>A single list containing pairs of matching elements from the input lists.</returns>
        [<CompiledName("Zip")>]
        val zip: list1:'T1 list -> list2:'T2 list -> ('T1 * 'T2) list

        /// <summary>Combines the three lists into a list of triples. The lists must have equal lengths.</summary>
        /// <param name="list1">The first input list.</param>
        /// <param name="list2">The second input list.</param>
        /// <param name="list3">The third input list.</param>
        /// <returns>A single list containing triples of matching elements from the input lists.</returns>
        [<CompiledName("Zip3")>]
        val zip3: list1:'T1 list -> list2:'T2 list -> list3:'T3 list -> ('T1 * 'T2 * 'T3) list
