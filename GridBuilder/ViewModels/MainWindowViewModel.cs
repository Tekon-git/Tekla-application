using GridBuilder.Models;
using GridBuilder.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GridBuilder.ViewModels
{
    class MainWindowViewModel
    {
        VisualGridModel visualGridModel = new VisualGridModel();
        public List<(int, double)> ListValueX
        {
            get => visualGridModel.ListStepsX;
            set
            {
                visualGridModel.ListStepsX = value;
                visualGridModel.SetTransform(GetParentSize().Item1, GetParentSize().Item2);
            }
        }
        public List<(int, double)> ListValueY
        {
            get => visualGridModel.ListStepsY;
            set
            {
                visualGridModel.ListStepsY = value;
                visualGridModel.SetTransform(GetParentSize().Item1, GetParentSize().Item2);
            }
        }
        public List<double> ListValueZ
        {
            get => visualGridModel.ListStepsZ;
            set
            {
                visualGridModel.ListStepsZ = value;
                visualGridModel.SetTransform(GetParentSize().Item1, GetParentSize().Item2);
            }
        }
        public List<string> ListMarkX
        {
            get => visualGridModel.ListMarkX;
            set
            {
                visualGridModel.ListMarkX = value;
                visualGridModel.SetTransform(GetParentSize().Item1, GetParentSize().Item2);
            }
        }
        public List<string> ListMarkY
        {
            get => visualGridModel.ListMarkY;
            set
            {
                visualGridModel.ListMarkY = value;
                visualGridModel.SetTransform(GetParentSize().Item1, GetParentSize().Item2);
            }
        }
        public List<string> ListMarkZ
        {
            get => visualGridModel.ListMarkZ;
            set
            {
                visualGridModel.ListMarkZ = value;
                visualGridModel.SetTransform(GetParentSize().Item1, GetParentSize().Item2);
            }
        }

        public GeometryGroup GridGeometr { get => visualGridModel.Geometry; }
        private (double, double) GetParentSize()
        {
            var win = Application.Current.MainWindow;
            var grArray = Extensions.FindVisualChildren<Grid>(win);
            Grid grid = grArray.Where(n => n.Name == "grid_Parent").FirstOrDefault();
            return (grid.ActualWidth, grid.ActualHeight); 
        }

        private RelayCommand resizeCommand;
        public RelayCommand ResizeCommand
        {
            get
            {
                return resizeCommand ??
                    (resizeCommand = new RelayCommand(obj =>
                    {
                        Grid gr = obj as Grid;
                        double w = gr.ActualWidth;
                        double h = gr.ActualHeight;
                        visualGridModel.SetTransform(w, h);
                    }));
            }
        }

        private RelayCommand createTSObjectCommand;
        public RelayCommand CreateTSObjectCommand
        {
            get
            {
                return createTSObjectCommand ??
                    (createTSObjectCommand = new RelayCommand(obj =>
                    {
                        TSGridModel gridModel = new TSGridModel(ListValueX, ListValueY, ListValueZ,
                            ListMarkX, ListMarkY, ListMarkZ);
                        gridModel.GridInsert();
                    }));
            }
        }



    }
}
