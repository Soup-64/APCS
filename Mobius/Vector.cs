
namespace Engine
{
	public class Vec2
	{
		public int X { get; set; }
		public int Y { get; set; }

		public Vec2()
		{
			X = 0;
			Y = 0;
		}
		public Vec2(int x, int y)
		{
			this.X = x;
			this.Y = y;
		}

		public Vec2 Add(Vec2 other)
		{
			return new Vec2(X + other.X, Y + other.Y);
		}

		public Vec2 Multiply(Vec2 other)
		{
			return new Vec2(X * other.X, Y * other.Y);
		}

		public Vec2 Multiply(int other)
		{
			return new Vec2(X * other, Y * other);
		}

		public override string ToString()
		{
			return $"({X}, {Y})";
		}
	}
}