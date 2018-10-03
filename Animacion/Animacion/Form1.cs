using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Animacion
{
    public partial class Form1 : Form
    {      
        Image imagen;
        Image enemi;
        aDer d;
        aIzq i;
        Abajo down;
        Arriba aUp;
        Anima ab;
        Timer t;
        Enemigo Ex;
        int x = 0;
        int y = 0;
        int tam = 50;

        public Form1()
        {

            InitializeComponent();
            t = new Timer();
            t.Interval = 100;
            t.Tick += t_tick;
            enemi = Image.FromFile("malo.png");
            imagen = Image.FromFile("img1.png");
            t.Start();
            i = new aIzq();
            ab = new Anima();
            aUp = new Arriba();
            d = new aDer();
            down = new Abajo();
            Ex = new Enemigo(200, 200, enemi,tam);
            

            ab.addFrame((Bitmap)Image.FromFile("fijo1.png"));
            ab.addFrame((Bitmap)Image.FromFile("fijo2.png"));
            ab.addFrame((Bitmap)Image.FromFile("fijo3.png"));
            ab.addFrame((Bitmap)Image.FromFile("fijo4.png"));
            ab.addFrame((Bitmap)Image.FromFile("fijo5.png"));

           /* d.addFrame((Bitmap)Image.FromFile("der1.png"));
            d.addFrame((Bitmap)Image.FromFile("der25.png"));
            d.addFrame((Bitmap)Image.FromFile("der2.png"));*/
        }

        void t_tick(object sender, EventArgs e)
        {
            ab.update();
            down.update();
            d.update();
            i.update();
            aUp.update();
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // e.Graphics.DrawImage(imagen, 15, 15, 100, 100);
            Bitmap aba = down.GetCurrentFrame();
            Bitmap b = ab.GetCurrentFrame();
            Bitmap dere = d.GetCurrentFrame();
            Bitmap izqu = i.GetCurrentFrame();
            Bitmap up = aUp.GetCurrentFrame();
            if (b != null)
            {
                e.Graphics.DrawImage(b, x, y, 100, 100);
                Ex.Dibujar(e);
            }
            if (dere != null)
            {
                e.Graphics.DrawImage(dere, x, y, 100, 100);
                Ex.Dibujar(e);
            }
            if (izqu != null)
            {
                e.Graphics.DrawImage(izqu, x, y, 100, 100);
                Ex.Dibujar(e);
            }
            if (aba != null)
            {
                e.Graphics.DrawImage(aba, x, y, 100, 100);
                Ex.Dibujar(e);
            }
            if (up != null)
            {
                e.Graphics.DrawImage(up, x, y, 100, 100);
                Ex.Dibujar(e);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
           
            Invalidate();
            switch (e.KeyData)
            {
                case Keys.Left:
                    if(x >= -5 && x < this.Width)
                    {
                        down.DeleteFrame();
                        ab.DeleteFrame();
                        d.DeleteFrame();
                        aUp.DeleteFrame();
                        i.addFrame((Bitmap)Image.FromFile("izq1.png"));
                        i.addFrame((Bitmap)Image.FromFile("izq2.png"));
                        i.addFrame((Bitmap)Image.FromFile("izq3.png"));
                        x -= 10;
                    }
                    break;
                case Keys.Right:
                    if (x >= -5 && x < this.Width-100)
                    {
                        // if (x < Ex.Dx && y > Ex.Dy) 
                        ab.DeleteFrame();
                        aUp.DeleteFrame();
                        i.DeleteFrame();
                        down.DeleteFrame();
                        d.addFrame((Bitmap)Image.FromFile("der1.png"));
                        d.addFrame((Bitmap)Image.FromFile("der25.png"));
                        d.addFrame((Bitmap)Image.FromFile("der2.png"));
                        x += 10;
                            
                        
                    }
                    break;
                case Keys.Down:
                    if (y >= -5 && y < this.Height-100)
                    {
                        d.DeleteFrame();
                        i.DeleteFrame();
                        ab.DeleteFrame();
                        aUp.DeleteFrame();
                        down.addFrame((Bitmap)Image.FromFile("abajo1.png"));
                        down.addFrame((Bitmap)Image.FromFile("abajo2.png"));
                        
                        y += 10;
                    }
                    break;
                case Keys.Up:
                    if (y >= -5 && y < this.Height-100)
                    {
                        ab.DeleteFrame();
                        i.DeleteFrame();
                        down.DeleteFrame();
                        d.DeleteFrame();
                        aUp.addFrame((Bitmap)Image.FromFile("arriba1.png"));
                        aUp.addFrame((Bitmap)Image.FromFile("arriba2.png"));
                        aUp.addFrame((Bitmap)Image.FromFile("arriba3.png"));
                        y -= 10;
                    }
                    break;
            }
        }

        private bool colision()
        {
            if (x+100 < Ex.Dx && y > Ex.Dy && y <Ex.Dy)
            {
                //return choca = true;
            }
            /*if (x > Ex.Dx + tam && y +100 < Ex.Dy)
            {
                return choca = false;
            }
            if( y+100)
            {

            }*/

                return false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
           
        }
    }
}
