using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.common_file
{
   public class My_eventArgs:EventArgs
    {
        private Panel myPanel;

       public Panel MyPanel
        {
            get { return myPanel; }
            set { myPanel = value; }
        }

	
    }
}
