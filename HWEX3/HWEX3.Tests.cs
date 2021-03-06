using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace HW3EX3
{
    [TestClass]
    public class CalculateAreaShouldReturn
    {
        [TestMethod]
        public void SixFor2X3Rectangle()
        {
            var myRectangle = new Rectangle { Height = 2, Width = 3 };
            Assert.AreEqual(6, AreaCalculator.CalculateArea(myRectangle));
        }   

        [TestMethod]
        public void NineFor3X3Square()
        {
            var mySquare = new Square() { Height = 3 };
            Assert.AreEqual(9, AreaCalculator.CalculateArea(mySquare));
        }

        [TestMethod]
        public void TwentyFor4X5RectangleFromSquare()
        {
            Rectangle newRectangle = new Square();
            newRectangle.Width = 4;
            newRectangle.Height = 5;
            Assert.AreEqual(20, AreaCalculator.CalculateArea(newRectangle));
        }



        [TestMethod]
        public void TwentyFor4X5ShapeFromRectangle()
        {
            Shape myShape = new Rectangle() { Height = 4, Width = 5 };
            Assert.AreEqual(20, myShape.Area());
        }

        [TestMethod]
        public void TwentyFor4X5ShapeFromRectangleAnd9For3X3Square()
        {
            var shapes = new List<Shape>
                             {
                                 new Rectangle {Height = 4, Width = 5},
                                 new Square {SideLength = 3}
                             };
            var areas = new List<int>();
            foreach (Shape shape in shapes)
            {
                areas.Add(shape.Area());
            }
            Assert.AreEqual(20, areas[0]);
            Assert.AreEqual(9, areas[1]);
        }


    }


    public class AreaCalculator
    {
        public static int CalculateArea(Rectangle r)
        {
            return r.Height * r.Width;
        }

        public static int CalculateArea(Square s)
        {
            return s.Height * s.Height;
        }
    }

    public class Rectangle: Shape
    {
        public override int Height { get; set; }
        public override int Width { get; set; }


        public override int Area()
        {
            return Height * Width;
        }
    }


    public class Square: Rectangle
    {
        public override int Height { get; set; }
        public override int Width { get; set; }
        public int SideLength { get; set; }

        public override int Area()
        {
            return SideLength * SideLength;
        }
    }

    public abstract class Shape
    {

        public abstract int Height { get; set; }
        public abstract int Width { get; set; }

        public abstract int Area();

    }


    // Square is not transfering to rectangle which is why the last test is failing
    //public class Square : Rectangle
    //{
    //    private int _height;
    //    private int _width;

    //    public override int Width
    //    {
    //        get { return _width; }
    //        set
    //        {
    //            _width = value;
    //            _height = value;
    //        }
    //    }

    //    public override int Height
    //    {
    //        get { return _height; }
    //        set
    //        {
    //            _width = value;
    //            _height = value;
    //        }
    //    }
    //}

}

#region Later

//public class Rectangle
//{
//    public virtual int Height { get; set; }
//    public virtual int Width { get; set; }

//    public bool IsSquare()
//    {
//        return Height == Width;
//    }
//}


#endregion