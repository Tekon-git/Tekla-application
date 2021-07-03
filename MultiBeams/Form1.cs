using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TSM = Tekla.Structures.Model;
using Tekla.Structures.Model.UI;
using TSG = Tekla.Structures.Geometry3d;
using System.Collections;

namespace TwoBeams
{
    public partial class Form1 : Tekla.Structures.Dialog.ApplicationFormBase
    {
        TSM.Model model;

        public Form1()
        {
            InitializeComponent();
            InitializeForm();

            this.model = new TSM.Model();

            if (!this.model.GetConnectionStatus())
            {
                MessageBox.Show("Tekla is not running");
            }
        }

        private void btn_multiBeams_Click(object sender, EventArgs e)
        {
            try
            {
                Picker picker = new Picker();
                ArrayList points = picker.PickPoints(Picker.PickPointEnum.PICK_POLYGON);

                if (points.Count >= 3)
                {
                    TSG.Point start = new TSG.Point(0, 0, 0);
                    TSG.Point middle = new TSG.Point(0, 0, 0);
                    TSG.Point end = new TSG.Point(0, 0, 0);
                    TSG.Vector vectorFit = new TSG.Vector();
                    TSG.Vector vectorZ = new TSG.Vector();
                    TSG.Vector vectorOne = new TSG.Vector();
                    TSG.Vector vectorTwo = new TSG.Vector();

                    ArrayList listBeams = new ArrayList();
                    ArrayList listPlates = new ArrayList();

                    double angelDegree = 0.0;

                    for (int i = 0; i < points.Count - 1; i++)
                    {
                        TSM.Beam beam = BeamFirst(points[i] as TSG.Point, points[i + 1] as TSG.Point);
                        beam.Insert();
                        listBeams.Add(beam);
                        this.model.CommitChanges();
                    }

                    double primaryWidth = 0.0;
                    double primaryHeight = 0.0;

                    for (int i = 0; i < points.Count - 1; i++)
                    {

                        try
                        {
                            start = points[i] as TSG.Point;
                            middle = points[i + 1] as TSG.Point;
                            end = points[i + 2] as TSG.Point;
                        }
                        catch
                        {

                        }

                        vectorOne = new TSG.Vector(middle.X - start.X, middle.Y - start.Y, middle.Z - start.Z);
                        vectorOne.Normalize();
                        vectorTwo = new TSG.Vector(middle.X - end.X, middle.Y - end.Y, middle.Z - end.Z);
                        vectorTwo.Normalize();
                        double angle = vectorOne.GetAngleBetween(vectorTwo);
                        angelDegree = angle * 180 / Math.PI;

                        //TSG.Vector vectorFit = new TSG.Vector(1 * Math.Cos(angle / 2), 1 * Math.Cos(angle / 2), 0);
                        vectorFit = new TSG.Vector(vectorOne.X + vectorTwo.X, vectorOne.Y + vectorTwo.Y, vectorOne.Z + vectorTwo.Z);
                        vectorZ = vectorOne.Cross(vectorTwo);

                        TSG.CoordinateSystem coordinateSystem = new TSG.CoordinateSystem();

                        double thick;
                        if (tb_thcikPlates.Text != string.Empty)
                        {
                            double.TryParse(tb_thcikPlates.Text, out thick);
                        }
                        else
                        {
                            thick = 20.0;
                        }

                        double offset = thick;
                        double angleFD = 90 - (angelDegree / 2);
                        double angleFR = Math.PI * angleFD / 180;

                        double width = 0.0;
                        double heigth = 0.0;

                        double x = Math.Round(vectorFit.X, 2, MidpointRounding.ToEven);
                        double y = Math.Round(vectorFit.Y, 2, MidpointRounding.ToEven);
                        double z = Math.Round(vectorFit.Z, 2, MidpointRounding.ToEven);


                        TSM.Beam beam1 = listBeams[i] as TSM.Beam;
                        TSM.Beam beam2 = listBeams[i + 1] as TSM.Beam;
                        beam1.GetReportProperty("WIDTH", ref primaryWidth);
                        beam1.GetReportProperty("HEIGHT", ref primaryHeight);

                        if (x == 0.0 && y == 0.0 && z == 0.0)
                        {

                            TSG.Vector bAxisX = beam1.GetCoordinateSystem().AxisX;
                            TSG.Vector bAxisY = beam1.GetCoordinateSystem().AxisY;
                            TSG.Vector bAxisZ = bAxisY.Cross(bAxisX);

                            coordinateSystem = new TSG.CoordinateSystem(middle, bAxisZ, bAxisY);
                        }
                        else
                        {
                            coordinateSystem = new TSG.CoordinateSystem(
                              middle, vectorFit, vectorZ);
                        }

                        TSM.WorkPlaneHandler planeHandler = model.GetWorkPlaneHandler();

                        TSM.TransformationPlane original = planeHandler.GetCurrentTransformationPlane();
                        TSM.TransformationPlane beamPlane = new TSM.TransformationPlane(coordinateSystem);
                        planeHandler.SetCurrentTransformationPlane(beamPlane);

                        FitBeam(beam1, -offset);
                        FitBeam(beam2, offset);

                        if (z != 0)
                        {

                            vectorZ = vectorTwo.Cross(vectorOne);

                            planeHandler.SetCurrentTransformationPlane(original);
                            TSG.CoordinateSystem coordinatePlate = new TSG.CoordinateSystem(
                           middle, vectorZ, vectorFit);

                            TSM.TransformationPlane beamPlate = new TSM.TransformationPlane(coordinatePlate);
                            planeHandler.SetCurrentTransformationPlane(beamPlate);

                            width = primaryWidth;
                            heigth = 50 + primaryHeight / (Math.Cos(angleFR));
                        }
                        else
                        {
                            width = 50 + primaryWidth / (Math.Cos(angleFR));
                            heigth = primaryHeight;
                        }


                        bool positionPlate = true;

                        for (int k = 0; k < 2; k++)
                        {

                            TSM.ContourPlate plate = PlateFirst(width, heigth, offset);
                            if (positionPlate)
                            {
                                plate.Position.Depth = TSM.Position.DepthEnum.BEHIND;
                                positionPlate = false;
                            }
                            else
                            {
                                plate.Position.Depth = TSM.Position.DepthEnum.FRONT;
                            }
                            plate.Insert();
                            listPlates.Add(plate);
                        }

                        TSM.ContourPlate plate1 = listPlates[0] as TSM.ContourPlate;
                        TSM.ContourPlate plate2 = listPlates[1] as TSM.ContourPlate;

                        BoltPlatetoPlate(plate1, plate2, heigth, width);

                        WeldBeamToPlate(beam1, plate1);
                        WeldBeamToPlate(beam2, plate2);

                        planeHandler.SetCurrentTransformationPlane(original);

                        this.model.CommitChanges();
                        listPlates.Clear();
                    }

                    this.model.CommitChanges();

                    listBeams.Clear();
                }
                else
                {

                    MessageBox.Show(Tekla.Structures.Dialog.UIControls.LocalizeForm.Localization.GetText("albl_Invalid_input_parts"));//translation of text in message box

                }
            }
            catch
            {


            }
        }

        public TSM.Beam BeamFirst(TSG.Point pointFirst, TSG.Point pointSecond)
        {
            TSM.Beam beam = new TSM.Beam();
            beam.StartPoint = pointFirst;
            beam.EndPoint = pointSecond;
            if (tb_profileBeams.Text != string.Empty)
            {
                beam.Profile.ProfileString = tb_profileBeams.Text; 
            }
            else
            {
                beam.Profile.ProfileString = "HEA300";
            }

            if (tb_materialBeams.Text != string.Empty)
            {
                beam.Material.MaterialString = tb_materialBeams.Text; 
            }
            else
            {
                beam.Material.MaterialString = "S235";
            }
            beam.Class = "3";
            beam.Position.Depth = TSM.Position.DepthEnum.MIDDLE;
            if (tb_nameBeams.Text != string.Empty)
            {
                beam.Name = tb_nameBeams.Text; 
            }
            else
            {
                beam.Name = "Beam";
            }

            return beam;
        }


        private void FitBeam(TSM.Beam beam, double offset)
        {
            TSM.Fitting fitting = new TSM.Fitting();

            fitting.Father = beam;

            TSM.Plane fitPlane = new TSM.Plane();
            fitPlane.Origin = new TSG.Point(0, 0, offset);
            fitPlane.AxisX = new TSG.Vector(1, 0, 0);
            fitPlane.AxisY = new TSG.Vector(0, 1, 0);

            fitting.Plane = fitPlane;

            fitting.Insert();
        }

        private void DrawPoint(TSG.Point location, string comment)
        {
            TSM.UI.GraphicsDrawer drawer = new TSM.UI.GraphicsDrawer();
            drawer.DrawText(location, comment, new TSM.UI.Color(1, 0, 0));
        }

        private void DrawCoordinateSystem()
        {
            TSM.UI.GraphicsDrawer drawer = new TSM.UI.GraphicsDrawer();

            TSG.Point origin = new TSG.Point();
            TSG.Point pointX = new TSG.Point(3000, 0, 0);
            TSG.Point pointY = new TSG.Point(0, 3000, 0);
            TSG.Point pointZ = new TSG.Point(0, 0, 3000);
            TSM.UI.Color blue = new TSM.UI.Color(0, 0, 1);
            TSM.UI.Color red = new TSM.UI.Color(1, 0, 0);

            drawer.DrawText(pointX, "X", blue);
            drawer.DrawText(pointY, "Y", blue);
            drawer.DrawText(pointZ, "Z", blue);

            drawer.DrawLineSegment(origin, pointX, red);
            drawer.DrawLineSegment(origin, pointY, red);
            drawer.DrawLineSegment(origin, pointZ, red);
        }

        public TSM.ContourPlate PlateFirst(double width, double height, double offset)
        {

            TSM.ContourPlate plate = new TSM.ContourPlate();

            //inicialize input points
            TSG.Point p1 = new TSG.Point(width / 2, height / 2, 0);
            TSG.Point p2 = new TSG.Point(width / 2, -height / 2, 0);
            TSG.Point p3 = new TSG.Point(-width / 2, -height / 2, 0);
            TSG.Point p4 = new TSG.Point(-width / 2, height / 2, 0);

            //set contour points
            plate.AddContourPoint(new TSM.ContourPoint(p1, null));
            plate.AddContourPoint(new TSM.ContourPoint(p2, null));
            plate.AddContourPoint(new TSM.ContourPoint(p3, null));
            plate.AddContourPoint(new TSM.ContourPoint(p4, null));
            plate.Profile.ProfileString = "PL" + offset;
            if (tb_materialPlates.Text != string.Empty)
            {
                plate.Material.MaterialString = tb_materialPlates.Text; 
            }
            else
            {
                plate.Material.MaterialString = "S235";
            }
            if (tb_namePlates.Text != string.Empty)
            {
                plate.Name = tb_namePlates.Text; 
            }
            else
            {
                plate.Name = "Plate";
            }
            return plate;
        }

        private void BoltPlatetoPlate(TSM.ContourPlate plate1, TSM.ContourPlate plate2, double height, double width)
        {

            TSM.BoltArray B = new TSM.BoltArray();

            B.PartToBeBolted = plate1;
            B.PartToBoltTo = plate2;

            B.FirstPosition = new TSG.Point(0, -height / 2, 0);
            B.SecondPosition = new TSG.Point(0, height / 2, 0);

            B.BoltSize = double.Parse(boltCatalogSize1.Text);
            B.Tolerance = 3.00;
            B.BoltStandard = boltCatalogStandard1.Text;
            B.BoltType = TSM.BoltGroup.BoltTypeEnum.BOLT_TYPE_SITE;
            B.CutLength = 105;

            B.Length = 100;
            B.ExtraLength = 0;
            B.ThreadInMaterial = TSM.BoltGroup.BoltThreadInMaterialEnum.THREAD_IN_MATERIAL_NO;

            B.Position.Depth = TSM.Position.DepthEnum.MIDDLE;
            B.StartPointOffset.Dx = height / 4;
            B.Position.Plane = TSM.Position.PlaneEnum.MIDDLE;
            B.Position.Rotation = TSM.Position.RotationEnum.FRONT;

            B.Bolt = true;
            B.Washer1 = true;
            B.Washer2 = true;
            B.Washer3 = true;
            B.Nut1 = true;
            B.Nut2 = false;

            B.Hole1 = true;
            B.Hole2 = true;
            B.Hole3 = true;
            B.Hole4 = true;
            B.Hole5 = true;

            B.AddBoltDistX(height / 2);
            B.AddBoltDistY(width / 2);

            B.Insert();
        }

        private void WeldBeamToPlate(TSM.Beam beam, TSM.ContourPlate plate)
        {
            TSM.Weld weld = new TSM.Weld();

            weld.MainObject = beam;
            weld.SecondaryObject = plate;
            weld.ConnectAssemblies = true;
            weld.SizeAbove = 5;
            weld.Insert();
        }

       

       
        private void materialCatalogBeams_SelectClicked(object sender, EventArgs e)
        {
            this.materialCatalogBeams.SelectedMaterial = tb_materialBeams.Text;
        }

        private void materialCatalogBeams_SelectionDone(object sender, EventArgs e)
        {
            this.tb_materialBeams.Text = this.materialCatalogBeams.SelectedMaterial;
        }

        private void materialCatalog1_SelectClicked(object sender, EventArgs e)
        {
            materialCatalog1.SelectedMaterial = tb_materialPlates.Text;
        }

        private void materialCatalog1_SelectionDone(object sender, EventArgs e)
        {
            this.tb_materialPlates.Text = this.materialCatalog1.SelectedMaterial;
        }

        private void profileCatalogBeams_SelectClicked(object sender, EventArgs e)
        {
            this.profileCatalogBeams.SelectedProfile = tb_profileBeams.Text;
        }

        private void profileCatalogBeams_SelectionDone(object sender, EventArgs e)
        {
            this.tb_profileBeams.Text = this.profileCatalogBeams.SelectedProfile;
        }

       
    }
}
