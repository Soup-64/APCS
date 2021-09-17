using System;
using Eto.Drawing;
using Eto.Forms;

namespace Engine
{
	public class Bouncy_square : Rect   //test object for the engine
	{
		private int point1 = 0; //these keep track of what points on the rect are hit, allowing for better bouncing
		private int point2 = 0;

		private int max = 2;

		private readonly Random rand = new();
		private readonly Vec2 velocity = new();
		public Bouncy_square(int x, int y, int width, int height, Color color) : base(x, y, width, height, color, true)
		{
			velocity.X = rand.Next(-max, max);
			velocity.Y = rand.Next(-max, max);
		}
		public override void Hit(Node other, int a) //a is the point that is colliding
		{
			point2 = point1;
			point1 = a;

			Bounce(other);
			base.Hit(other, a);
		}
		public override void On_frame(object sender, PaintEventArgs pe)
		{
			base.On_frame(sender, pe);
			position.X += velocity.X;
			position.Y += velocity.Y;

			if (position.X > 800 || position.Y > 600 || position.X < 0 || position.Y < 0)
			{
				position = new Vec2(400, 300);
			}
		}
		public override void On_keydown(object sender, KeyEventArgs e)
		{
			base.On_keydown(sender, e);
		}

		private void Bounce(Node node) //gets run per shape it hits
		{
			Vec2 other = node.Get_center();
			Vec2 center = Get_center();

			if (!node.GetType().Equals(GetType()))
			{
				if (point2 == 1 && point1 == 2) //if to the right
				{
					velocity.X = rand.Next(-max, -1);
				}
				else if (point2 == 0 && point1 == 3)
				{
					velocity.X = rand.Next(1, max);
				}
				else if (point2 == 2 && point1 == 3) //if below
				{
					velocity.Y = rand.Next(-max, -1);
				}
				else if (point2 == 0 && point1 == 1)
				{
					velocity.Y = rand.Next(1, max);
				}
			}
			else
			{
				if (other.X > center.X) //if to the right
				{
					velocity.X = rand.Next(-max, -1);
				}
				else
				{
					velocity.X = rand.Next(1, max);
				}
				
				if (other.Y > center.Y) //if below
				{
					velocity.Y = rand.Next(-max, -1);
				}
				else
				{
					velocity.Y = rand.Next(1, max);
				}
			}

		}
	}
}