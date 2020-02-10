﻿@ModelType IEnumerable(Of lab_53_mvc_framework_demo.lab_53_mvc_framework_demo.User)
@Code
ViewData("Title") = "Index"
End Code

<h2>Index</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.UserName)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.DateOfBirth)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.isValid)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Category.CategoryName)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.UserName)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.DateOfBirth)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.isValid)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Category.CategoryName)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.UserID }) |
            @Html.ActionLink("Details", "Details", New With {.id = item.UserID }) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.UserID })
        </td>
    </tr>
Next

</table>
