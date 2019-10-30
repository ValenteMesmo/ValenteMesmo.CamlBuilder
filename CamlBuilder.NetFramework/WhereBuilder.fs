﻿namespace ValenteMesmo.CamlQueryBuilder.Internals

open ValenteMesmo.CamlQueryBuilder.Internals.Xml.XmlNodeFactories
open ValenteMesmo.CamlQueryBuilder.Internals.PartPicker

//TODO: create queryBuilder
// view>
//    query>
//          orderby
//          where
//    viewFields
//    rowlimit
type WhereBuilder(handler : System.Func<FieldTypePicker, LogicalOperatorPicker>) =        
    let whereContent = 
        fun f -> f
        |> FieldTypePicker
        |> handler.Invoke 
    
    member this.Build() =
        whereContent.Build()
        |> createWhereNode
        |> createQueryNode
        |> createViewNode

    member this.RowLimit number =        
        (
            whereContent.Build()
            |> createWhereNode
            |> createQueryNode, number
        )
        |> RowContentBuilder
        

and RowContentBuilder(parentBuild, number : int) =
    member this.Build() =
        parentBuild + createRowLimitNode(number)
        |> createViewNode