﻿namespace ValenteMesmo.CamlQueryBuilder.Internals

open ValenteMesmo.CamlQueryBuilder.Internals.Xml.XmlNodeFactories
open ValenteMesmo.CamlQueryBuilder.Internals.PartPicker
open RowContentBuilderModule
open System

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
            |> createQueryNode
            , number
        )
        |> RowContentBuilder

    member this.ViewFields ([<ParamArray>]fields : string array) =
        (
            whereContent.Build()
            |> createWhereNode
            |> createQueryNode
            , fields
        )
        |> ViewFieldsBuilder
    
    member this.OrderBy fieldName =
        OrderByBuilder (whereContent.Build() |> createWhereNode, fieldName)
    
    member this.OrderByDesc fieldName =
        OrderByBuilder (whereContent.Build() |> createWhereNode, fieldName)