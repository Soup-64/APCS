using System;
using System.Collections.Generic;

namespace Engine
{
	public class Fizz //the physics/collision detector
	{
		public static void Run(ref List<Node> pnodes, Node[] nodes)
		{
			for (int i = 0; i < pnodes.Count; i++) //for each physics marked node
			{
				Vec2[] poly = pnodes[i].Get_shape();

				for (int a = 0; a < poly.Length; a++) //for every point in that node
				{
					for (int j = 0; j < nodes.Length; j++) //do some physics with all other nodes
					{
						if (nodes[j] != pnodes[i])
						{
							if (Is_colliding(nodes[j].Get_shape(), poly[a])) //if point is in shape
							{
								pnodes[i].is_colliding = true;
								pnodes[i].Hit(nodes[j], a);

								if (nodes[j].Does_collisions)
								{
									nodes[j].is_colliding = true;
									nodes[j].Hit(pnodes[i], a);
								}
							}
							else
							{
								pnodes[i].is_colliding = false;

								if (nodes[j].Does_collisions)
								{
									nodes[j].is_colliding = false;
								}
							}
						}
					}
				}
			}
		}

		private static bool Is_colliding(Vec2[] poly, Vec2 point)
		{
			int i, j;
			bool c = false;
			for (i = 0, j = poly.Length - 1; i < poly.Length; j = i++) //even odd rule algorithm I stole from stackoverflow 
			{
				if ((((poly[i].X <= point.X) && (point.X < poly[j].X))
						|| ((poly[j].X <= point.X) && (point.X < poly[i].X)))
						&& (point.Y < (poly[j].Y - poly[i].Y) * (point.X - poly[i].X)
							/ (poly[j].X - poly[i].X) + poly[i].Y))
				{
					c = !c;
				}
			}
			return c;
		}
	}
}