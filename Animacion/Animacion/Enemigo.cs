using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Drawing;

namespace Animacion
{
    class Enemigo
    {

        private Image img;
       // private bool isDown = false;
        private int dx, dy;
        int tama;

        public Enemigo(int x, int y, Image imagen,int T)
            
        {
            dx = x;
            dy = y;
            img = imagen;
            tama = T;
        }


       
        public int Dx
        {
            get
            {
                return dx;
            }

            set
            {
                dx = value;
            }
        }

        public int Dy
        {
            get
            {
                return dy;
            }

            set
            {
                dy = value;
            }
        }

        public void Dibujar(PaintEventArgs e)
        {         
            e.Graphics.DrawImage(img, this.dx, this.dy,tama,tama);
            
        }
    }
}
