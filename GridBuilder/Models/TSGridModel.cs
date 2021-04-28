using GridBuilder.Infrastructure.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tekla.Structures.Model;

namespace GridBuilder.Models
{
    public class TSGridModel
    {
        private Grid grid;
        private Model model;

        public TSGridModel(List<(int,double)> stepsX, List<(int, double)> stepsY, List<double> stepsZ,
            List<string> markX, List<string> markY, List<string> markZ)
        {
            StringToListConverter converter = new StringToListConverter();
            StringToArrayStringConverter converterToString = new StringToArrayStringConverter();
            StringToDoubleArrayConverter converterToDouble = new StringToDoubleArrayConverter();

            grid = new Grid();
            grid.Name = "TeGrid";
            grid.LabelX = converterToString.Convert(markX, typeof(object), null, null).ToString();
            grid.LabelY = converterToString.Convert(markY, typeof(object), null, null).ToString();
            grid.LabelZ = converterToString.Convert(markZ, typeof(object), null, null).ToString();
            grid.CoordinateX =converter.Convert(stepsX, typeof(object), null, null).ToString();
            grid.CoordinateY = converter.Convert(stepsY, typeof(object), null, null).ToString();
            grid.CoordinateZ = converterToDouble.Convert(stepsZ, typeof(object), null, null).ToString();
        }

        public void GridInsert()
        {
            model = model ?? new Model();
            if(model.GetConnectionStatus())
            {
                grid.Insert();
                model.CommitChanges();
            }
        }
    }
}