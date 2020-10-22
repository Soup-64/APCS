using System;
using Terminal.Gui;

namespace comp_sci_chat_client
{
    public delegate void @delegate();
    public class gui
    {
        public event @delegate print;

        public void init(string name)
        {
            Application.Init();

            Toplevel top = Application.Top;

            Window win = new Window() //cool way to init without creating a long line of stuff
            {
                Title = name + "    -" + Environment.UserName,
                X = 0,
                Y = 1,

                Width = Dim.Fill(),
                Height = Dim.Fill()
            };

            MenuBar bar = new MenuBar (new MenuBarItem [] { //the bar

				new MenuBarItem ("_File", new MenuItem [] { //the category
					new MenuItem ("_Quit", "", () => handler() ), //the item
                    new MenuItem ("_say something", "", () =>  MessageBox.Query(20,5,"something","there, I said it", "ok"))
				}),
			});


            //MenuBar bar = new MenuBar(new MenuBarItem(item));
            

            Button btn = new Button(0, 2, "Ok");

            btn.Clicked += handler;

            
            
            win.Add(btn);

            Onprint();

            bar.ColorScheme = Colors.Menu;
            win.ColorScheme = Colors.Menu;

            Application.Top.Add(bar);
            Application.Top.Add(win);
            Application.Run();
            
        }

        private void handler()
        {
            int n = MessageBox.Query(20,5,"hi","hi person!!!", "ok", "goodbye");

            if(n == 1)
            {
                Application.RequestStop();
            }
        }



        protected virtual void Onprint()
        {
            print?.Invoke();
        }
    }
}