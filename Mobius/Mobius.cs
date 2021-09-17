using System.ComponentModel;
using System;
using Eto.Forms;
using Eto.Drawing;
using System.Collections.Generic;

namespace Engine
{
	public class Mobius //the main engine
	{
		public Mobius(Node[] nodes, string title, Size window_size)
		{
			Application app = new();
			Game main = new(nodes, title, window_size);

			app.Run(main);
		}
	}

	public class Game : Form
	{
		private readonly Node[] nodes; //master list of all items to be used in the scene

		private List<Node> physics_nodes = new();

		private bool physics_frame = true;

		private readonly Drawable drawable;

		public Game(Node[] nodes, string title, Size window_size)
		{
			drawable = new Drawable
			{
				Size = new Size(800, 600),
				BackgroundColor = Colors.Black
			};

			this.nodes = nodes;
			foreach (Node i in this.nodes)
			{
				if (i.Needs_input)
				{
					KeyDown += i.On_keydown;
				}
				if (i.Does_render)
				{
					drawable.Paint += i.On_frame;
				}
				if(i.Does_collisions)
				{
					physics_nodes.Add(i);
				}
			}
			drawable.Paint += Do_physics;

			Title = title;
			ClientSize = window_size;
			Content = drawable;
		}

		private void Do_physics(object sender, PaintEventArgs e) //runs every other frame
		{
			if (physics_frame)
			{
				Fizz.Run(ref physics_nodes, nodes);
				physics_frame = false;
			}
			else
			{
				physics_frame = true;
			}
		}
	}
}