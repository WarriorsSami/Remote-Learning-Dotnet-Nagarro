using System;
using System.Collections.ObjectModel;

namespace GeometrixWithoutOcp.ShapeModel
{
    internal class GeometricShapes : Collection<object>
    {
        public double CalculateArea()
        {
            double area = 0;

            foreach (var shape in Items)
            {
                switch (shape)
                {
                    case Rectangle rectangle:
                        area += rectangle.Width * rectangle.Height;
                        break;

                    case Circle circle:
                        area += circle.Radius * circle.Radius * Math.PI;
                        break;

                    case Triangle triangle:
                    {
                        var semiPerimeter = (triangle.SideA + triangle.SideB + triangle.SideC) / 2;
                        area += Math.Sqrt(semiPerimeter * (semiPerimeter - triangle.SideA) * 
                                          (semiPerimeter - triangle.SideB) * (semiPerimeter - triangle.SideC));
                        break;
                    }

                    default:
                        throw new Exception("Unknown shape.");
                }
            }

            return area;
        }
    }
}