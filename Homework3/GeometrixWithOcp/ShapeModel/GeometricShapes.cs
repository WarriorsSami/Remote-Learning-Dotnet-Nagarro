using System.Collections.ObjectModel;
using System.Linq;

namespace GeometrixWithOcp.ShapeModel
{
    internal class GeometricShapes : Collection<IShape>
    {
        public double CalculateArea()
        {
            return Items.Sum(shape => shape.CalculateArea());
        }
    }
}