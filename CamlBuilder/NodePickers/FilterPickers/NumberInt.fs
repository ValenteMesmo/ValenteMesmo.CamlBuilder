﻿namespace ValenteMesmo.CamlQueryBuilder

open ValenteMesmo.CamlQueryBuilder.Internals.Xml.XmlNodeFactories
open ValenteMesmo.CamlQueryBuilder.Internals.PartPicker
open System.Runtime.CompilerServices

[<Extension>]
type IntFieldFilterPickerExtensions =

    [<Extension>]
    static member IsNull(picker: NumberFieldFilterPicker) =
        picker.fieldDefinition
        |> createIsNullNode
        |> picker.Build
        |> LogicalOperatorPicker

    [<Extension>]
    static member IsNotNull(picker: NumberFieldFilterPicker) =
        picker.fieldDefinition
        |> createIsNotNullNode
        |> picker.Build
        |> LogicalOperatorPicker

    [<Extension>]    
    static member IsEqualTo(picker: NumberFieldFilterPicker, value : int) =
        createIntValueNode(value)
        |> concat picker.fieldDefinition
        |> createEqualNode
        |> picker.Build
        |> LogicalOperatorPicker

    [<Extension>]    
    static member IsNotEqualTo(picker: NumberFieldFilterPicker, value : int) =
        createIntValueNode(value)
        |> concat picker.fieldDefinition
        |> createNotEqualNode
        |> picker.Build
        |> LogicalOperatorPicker

    [<Extension>]
    static member IsGreaterThan(picker: NumberFieldFilterPicker, value : int) =
        createIntValueNode(value)
        |> concat picker.fieldDefinition
        |> createGreaterThanNode
        |> picker.Build
        |> LogicalOperatorPicker

    [<Extension>]
    static member IsLessThan(picker: NumberFieldFilterPicker, value : int) =
        createIntValueNode(value)
        |> concat picker.fieldDefinition
        |> createLessThanNode
        |> picker.Build
        |> LogicalOperatorPicker
