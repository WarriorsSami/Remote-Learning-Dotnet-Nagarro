using System;

namespace GeometrixWithOcp.ShapeModel
{
    internal class Triangle: IShape
    {
        public double SideA { get; set; }
        public double SideB { get; set; }
        public double SideC { get; set; }
        
        private double Perimeter => SideA + SideB + SideC;
        
        public double CalculateArea()
        {
            var semiPerimeter = Perimeter / 2;
            return Math.Sqrt(semiPerimeter * (semiPerimeter - SideA) * 
                             (semiPerimeter - SideB) * (semiPerimeter - SideC));
        }
    }
}