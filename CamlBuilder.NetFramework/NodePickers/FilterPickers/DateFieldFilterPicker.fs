﻿namespace ValenteMesmo.CamlQueryBuilder

open ValenteMesmo.CamlQueryBuilder.Internals.Xml.XmlNodeFactories
open ValenteMesmo.CamlQueryBuilder.Internals.PartPicker
open System.Runtime.CompilerServices

[<Extension>]
type DateFieldFilterPickerExtensions =

    [<Extension>]
    static member IsNull(picker: DateFieldFilterPicker) =
        picker.fieldDefinition
        |> createIsNullNode
        |> picker.Build
        |> LogicalOperatorPicker

    [<Extension>]
    static member IsLessThan (picker: DateFieldFilterPicker, value : System.DateTime) =
        picker.fieldDefinition + createDateOnlyValue(value)
        |> createLessThanNode
        |> picker.Build
        |> LogicalOperatorPicker