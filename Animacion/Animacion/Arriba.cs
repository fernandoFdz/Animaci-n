using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;


namespace Animacion
{
    class Arriba
    {
        private int CurrentIndex;
        private List<Bitmap> Frames;

        private int FrameCount, FramesPerBitmap;

        public Arriba()
        {
            CurrentIndex = -1;
            FramesPerBitmap = 1;
            FrameCount = 0;
            Frames = new List<Bitmap>();
        }

        public void addFrame(Bitmap m)
        {
            Frames.Add(m);
        }

        public void DeleteFrame()
        {
            Frames.Clear();
            // MessageBox.Show("paso aqui");

        }

        public void update()
        {
            if (Frames.Count == 0) return;
            FrameCount++;
            if (FrameCount >= FramesPerBitmap)
            {
                CurrentIndex++;
                if (CurrentIndex >= Frames.Count) CurrentIndex = -1;
                FrameCount = 0;

            }
        }

        public Bitmap GetCurrentFrame()
        {
            if (Frames.Count == 0) return null;
            if (CurrentIndex == -1) return null;

            return Frames[CurrentIndex];
        }
    }
}
