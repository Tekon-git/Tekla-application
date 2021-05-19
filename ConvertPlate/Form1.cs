using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TSG = Tekla.Structures.Geometry3d;
using TSM = Tekla.Structures.Model;
using Tekla.Structures.Model.UI;
using Tekla.Structures.Dialog;


namespace ConvertPlate
{
    public partial class Form1 : ApplicationFormBase
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

        private void btnConvert_Click(object sender, EventArgs e)
        {
            ModelObjectSelector mos = new ModelObjectSelector();

            TSM.ModelObjectEnumerator moe = mos.GetSelectedObjects();

            moe.SelectInstances = false;

            while (moe.MoveNext())
            {
                if (moe.Current is TSM.Part)
                {
                    TSM.Part part = moe.Current as TSM.Part;

                    // this method needs to be called to properly fill all the properties of the part
                    part.Select();

                    double partLength = 0.0;
                    double partHeight = 0.0;
                    double partWidth = 0.0;
                    part.GetReportProperty("LENGTH", ref partLength);
                    part.GetReportProperty("HEIGHT", ref partHeight);
                    part.GetReportProperty("WIDTH", ref partWidth);

                    TSM.ModelObjectEnumerator MyAllBooleans = part.GetBooleans();
                    TSM.ModelObjectEnumerator MyAllBolts = part.GetBolts();
                    TSM.ModelObject MyFather = part.GetFatherComponent();


                    TSG.CoordinateSystem coordinateSystem = part.GetCoordinateSystem();
                    TSM.WorkPlaneHandler planeHandler = model.GetWorkPlaneHandler();

                    // before we create a new plane we need to store the old one
                    TSM.TransformationPlane original = planeHandler.GetCurrentTransformationPlane();
                    TSM.TransformationPlane partPlane = new TSM.TransformationPlane(coordinateSystem);
                    planeHandler.SetCurrentTransformationPlane(partPlane);

                    //this.DrawCoordinateSystem();

                    TSG.Point p1 = new TSG.Point(0, partHeight / 2, 0);
                    TSG.Point p2 = new TSG.Point(partLength, partHeight / 2, 0);
                    TSG.Point p3 = new TSG.Point(partLength, -partHeight / 2, 0);
                    TSG.Point p4 = new TSG.Point(0, -partHeight / 2, 0);

                    TSM.ContourPlate CP = new TSM.ContourPlate();
                    TSM.ContourPoint conturePoint1 = new TSM.ContourPoint(p1, null);
                    TSM.ContourPoint conturePoint2 = new TSM.ContourPoint(p2, null);
                    TSM.ContourPoint conturePoint3 = new TSM.ContourPoint(p3, null);
                    TSM.ContourPoint conturePoint4 = new TSM.ContourPoint(p4, null);

                    CP.AddContourPoint(conturePoint1);
                    CP.AddContourPoint(conturePoint2);
                    CP.AddContourPoint(conturePoint3);
                    CP.AddContourPoint(conturePoint4);
                    CP.Name = "NEM";
                    CP.Finish = "xxx";
                    CP.Profile.ProfileString = "PL" + partWidth;
                    CP.Material.MaterialString = "S235";
                    CP.Class = "1";
                    
                    CP.Insert();

                    while (MyAllBooleans.MoveNext())
                    {
                        try
                        {
                            TSM.BooleanPart partBooleans = MyAllBooleans.Current as TSM.BooleanPart;

                            TSM.Part partBool = partBooleans.OperativePart as TSM.Part;
                            partBool.Class = TSM.BooleanPart.BooleanOperativeClassName;
                            partBool.Insert();

                            TSM.BooleanPart myboolpart = new TSM.BooleanPart();
                            myboolpart.Father = CP;
                            myboolpart.SetOperativePart(partBool);
                            myboolpart.Insert();
                            partBool.Delete();
                        }
                        catch (Exception)
                        {

                            throw;
                        }

                    }


                    while (MyAllBolts.MoveNext())
                    {
                        try
                        {
                            if (MyAllBolts.Current is TSM.BoltGroup)
                            {
                                TSM.BoltGroup b = MyAllBolts.Current as TSM.BoltGroup;

                                TSM.Part toBolted = b.PartToBeBolted as TSM.Part;
                                TSM.Part toBolt = b.PartToBoltTo as TSM.Part;
                                if (toBolted.Identifier.ID == toBolt.Identifier.ID)
                                {
                                    b.PartToBeBolted = CP;
                                    b.PartToBoltTo = CP;
                                }
                                else if (toBolted.Identifier.ID == part.Identifier.ID)
                                {
                                    b.PartToBoltTo.GetBolts();
                                    b.PartToBeBolted = CP;
                                }
                                else
                                {
                                    b.PartToBoltTo = CP;
                                    b.PartToBeBolted.GetBolts();

                                }
                                b.Insert();
                            }

                        }
                        catch (Exception)
                        {

                            throw;
                        }

                    }
                   
                    if (MyFather != null)
                    {
                        TSM.ModelObjectEnumerator elementOfComponenet = MyFather.GetChildren();
                        while (elementOfComponenet.MoveNext())
                        {
                            TSM.Part element = elementOfComponenet.Current as TSM.Part;
                            try
                            {
                                if (element is TSM.Part)
                                {
                                    if (element.Identifier.ID == part.Identifier.ID)
                                    {

                                        element = CP;
                                    
                                        element.Modify();
                                       
                                        
                                    }
                                    else
                                    {
                                        continue;
                                    }
                                }
                                else
                                    continue;
                                                          
                            }
                            catch (Exception)
                            {

                                throw;
                            }
                            
                        }
                    }



                   part.Delete();
                   planeHandler.SetCurrentTransformationPlane(original);
                }
            }

            this.model.CommitChanges();
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
    }

    
}
