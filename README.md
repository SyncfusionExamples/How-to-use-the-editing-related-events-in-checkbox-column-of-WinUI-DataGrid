# How to use the editing related events in GridCheckBoxColumn of WinUI DataGrid (SfDataGrid)?

The **BeginEdit** and **EndEdit** events are not triggered for [GridCheckBoxColumn](https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.DataGrid.GridCheckBoxColumn.html) when check or uncheck the CheckBox control in **GridCheckBoxColumn** in [WinUI DataGrid](https://www.syncfusion.com/winui-controls/datagrid) (SfDataGrid). However, you can trigger the **GridCheckBoxColumn** when the CheckBox control is checked or unchecked by using the [CurrentCellValueChanged](https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.DataGrid.SfDataGrid.html#Syncfusion_UI_Xaml_DataGrid_SfDataGrid_CurrentCellValueChanged) event.


```C#

//Event subscription
this.dataGrid.CurrentCellValueChanged += OnCurrentCellValueChanged;

//Event customization
public void OnCurrentCellValueChanged(object sender, CurrentCellValueChangedEventArgs args)
{
    int columnindex = dataGrid.ResolveToGridVisibleColumnIndex(args.RowColumnIndex.ColumnIndex);

    if (columnindex < 0)
        return;

    var column = dataGrid.Columns[columnindex];

    if (column is GridCheckBoxColumn)
    {
        var rowIndex = this.dataGrid.ResolveToRecordIndex(args.RowColumnIndex.RowIndex);

        if (rowIndex < 0)
            return;

        RecordEntry record = null;

        if (this.dataGrid.View != null)
        {
            if (this.dataGrid.View.TopLevelGroup != null)
            {
                //Get the record when grouping applied in SfDataGrid
                record = (this.dataGrid.View.TopLevelGroup.DisplayElements[rowIndex] as RecordEntry);
            }
            else
            {
                record = this.dataGrid.View.Records[rowIndex] as RecordEntry;
            }

            if (record != null)
            {
                //Checkbox property changed value is stored here.
                var value = (record.Data as OrderInfo).Review;
            }
        }
    }
}

```

Take a moment to peruse the [WinUI DataGrid - Column Types](https://help.syncfusion.com/winui/datagrid/column-types) documentation, to learn more about column types with code examples.
