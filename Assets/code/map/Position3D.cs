using System.Collections.Generic;
using UnityEngine;

namespace code.map
{
    public class Position3D
    {
        public Position3D() : this(0, 0, 0)
        {
        }

        public Position3D(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public IEnumerable<Position3D> GetPositionsInCubeRadius(int radius)
        {
            var posistions = new List<Position3D>();

            for (var deltaX = -radius; deltaX <= radius; deltaX++)
            for (var deltaY = -radius; deltaY <= radius; deltaY++)
            for (var deltaZ = -radius; deltaZ <= radius; deltaZ++)
                posistions.Add(new Position3D(x + deltaX, y + deltaY, z + deltaZ));

            return posistions;
        }

        public Position3D getPositionPlusX(int delta)
        {
            return new Position3D(x + delta, y, z);
        }

        public Position3D getPositionPlusY(int delta)
        {
            return new Position3D(x, y + delta, z);
        }

        public Position3D getPositionPlusZ(int delta)
        {
            return new Position3D(x, y, z + delta);
        }

        public override bool Equals(object obj)
        {
            var position = obj as Position3D;

            if (position == null)
                return false;

            return x == position.x && y == position.y && z == position.z;
        }

        public override int GetHashCode()
        {
            return 137 * x + 149 * y + 163 * z;
        }

        public override string ToString()
        {
            return "{x: " + x + ", y: " + y + ", z: " + z + "}";
        }

        public int x { get; set; }

        public int y { get; set; }

        public int z { get; set; }

        public static Vector3 operator *(Position3D position3D, Vector3 vector3)
        {
            return new Vector3(position3D.x * vector3.x, position3D.y * vector3.y, position3D.z * vector3.z);
        }

        public static Position3D operator *(Position3D position1, Position3D position2)
        {
            return new Position3D(position1.x * position2.x, position1.y * position2.y, position1.z * position2.z);
        }

        public static Position3D operator +(Position3D position1, Position3D position2)
        {
            return new Position3D(position1.x + position2.x, position1.y + position2.y, position1.z + position2.z);
        }
    }
}