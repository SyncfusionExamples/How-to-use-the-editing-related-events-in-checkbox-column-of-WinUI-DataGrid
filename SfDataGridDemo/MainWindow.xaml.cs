using Microsoft.UI.Xaml;
using Syncfusion.UI.Xaml.Data;
using Syncfusion.UI.Xaml.DataGrid;
using System.Diagnostics;
using Windows.UI.Popups;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace DataGridDemo
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();

            //Event subscription
            this.dataGrid.CurrentCellValueChanged += OnCurrentCellValueChanged;
        }

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
    }
}