using System;
using System.Collections.Generic;
using System.Drawing;
using w3bot.Api;
using Emgu.CV;
using Emgu.CV.Structure;
using w3bot.GUI;
using w3bot.Core.Processor;

namespace w3bot.Core
{
    class Debug
    {
        private static List<w3bot.Script.Bot.Drawable> debugs = new List<w3bot.Script.Bot.Drawable>();

        internal static w3bot.Script.Bot _bot;
        internal static int paintPos = 0;
        private static Font font = new Font("Arial", 8);
        private static int height = 13;
        private static double _threshold = 50, _thresholdLink = 20;
        private static SobelEdge sobel;
        private static CannyEdge canny;
        private static LaplacianEdge laplacian;
        private static Image<Bgr, byte> _imgInput;
        private static Image<Gray, byte> _imgCanny, _imgGray;
        private static Image<Gray, float> _imgSobel, _imgLaplacian;
        private static int _xorder = 1, _yorder = 0, _apertureSize = 3, _apertureSizeLaplacian = 7;
        private static IProcessor _processor;

        internal Debug(IProcessor processor)
        {
            _processor = processor;
        }

        internal static bool toggle(w3bot.Script.Bot.Drawable drawable)
        {
            bool added = true;
            if (debugs.Contains(drawable))
            {
                debugs.Remove(drawable);
                w3bot.Script.Bot.paintings -= drawable;
                added = false;
            }
            else
            {
                debugs.Add(drawable);
                w3bot.Script.Bot.paintings += drawable;
            }
            //_bot.core.Invalidate(); //causes repaint
            return added;
        }

        internal static void Mouse(Graphics g)
        {
            Pen greenPen = new Pen(Color.Green); //draws the mouse
            Point m = _processor.MousePos;
            g.DrawLine(greenPen, new Point(m.X - 5, m.Y - 5), new Point(m.X + 5, m.Y + 5));
            g.DrawLine(greenPen, new Point(m.X - 5, m.Y + 5), new Point(m.X + 5, m.Y - 5));
        }

        internal static void MousePosition(Graphics g)
        {
            paintPos++;
            g.DrawString("Mouse: " + _processor.MousePos.X + ", " + _processor.MousePos.Y, font, Brushes.Green, 5, paintPos * height);
        }

        internal static void ResetHeight(Graphics g)
        {
            paintPos = 0;
        }

        internal static void AddConfiguration(w3bot.Script.Bot bot)
        {
            _bot = bot;
            w3bot.Script.Bot.paintings += ResetHeight;
        }

        internal static void PixelColor(Graphics g)
        {
            paintPos++;
            Color p = Frame.MainFrame.GetPixel(_processor.MousePos.X, _processor.MousePos.Y);
            g.FillRectangle(new SolidBrush(Color.FromArgb(p.R, p.G, p.B)), 5, (paintPos * height) + 2, 10, 8);
            g.DrawRectangle(Pens.Black, 5, (paintPos * height) + 2, 10, 8);
            g.DrawString("R: " + p.R + ", G:" + p.G + " , B:" + p.B, font, Brushes.Green, 15, paintPos * height);
        }

        internal static void CannyEdges(Graphics g)
        {
            // singleton for frame image and canny
            if (_imgInput == null)
            {
                _imgInput = new Image<Bgr, byte>(Frame.MainFrame);
                _imgCanny = new Image<Gray, byte>(_imgInput.Width, _imgInput.Height, new Gray(0));
            }

            if (canny == null)
            {
                canny = new CannyEdge();
                canny.ShowDialog();
            }

            _imgCanny = _imgInput.Canny(_threshold, _thresholdLink);
            g.DrawImage(_imgCanny.ToBitmap(_imgInput.Width, _imgInput.Height), new Rectangle(0, 0, _imgInput.Width, _imgInput.Height));
            g.DrawString($"Threshold: {_threshold}, Threshold Link: {_thresholdLink}", font, Brushes.Green, 5, paintPos * height);
        }

        internal static void SobelEdges(Graphics g)
        {
            try
            {
                if (_imgGray == null)
                {
                    _imgInput = new Image<Bgr, byte>(Frame.MainFrame);
                    _imgGray = _imgInput.Convert<Gray, byte>();
                    _imgSobel = new Image<Gray, float>(_imgInput.Width, _imgInput.Height, new Gray(0));
                }

                if (sobel == null)
                {
                    sobel = new SobelEdge();
                    sobel.ShowDialog();
                }

                _imgSobel = _imgGray.Sobel(_xorder, _yorder, _apertureSize);
                g.DrawImage(_imgSobel.ToBitmap(_imgInput.Width, _imgInput.Height), new Rectangle(0, 0, _imgInput.Width, _imgInput.Height));
                g.DrawString($"X: {_xorder}, Y: {_yorder}, Aperture size: {_apertureSize}", font, Brushes.Green, 5, paintPos * height);
            }
            catch (Exception) { }
        }

        internal static void LaplacianEdges(Graphics g)
        {
            try
            {
                if (_imgGray == null)
                {
                    _imgInput = new Image<Bgr, byte>(Frame.MainFrame);
                    _imgGray = _imgInput.Convert<Gray, byte>();
                    _imgLaplacian = new Image<Gray, float>(_imgInput.Width, _imgInput.Height, new Gray(0));
                }

                if (laplacian == null)
                {
                    laplacian = new LaplacianEdge();
                    laplacian.ShowDialog();
                }

                _imgLaplacian = _imgGray.Laplace(_apertureSizeLaplacian);
                g.DrawImage(_imgLaplacian.ToBitmap(_imgInput.Width, _imgInput.Height), new Rectangle(0, 0, _imgInput.Width, _imgInput.Height));
                g.DrawString($"Aperture size: {_apertureSizeLaplacian}", font, Brushes.Green, 5, paintPos * height);
            }
            catch (Exception) { }
        }

        internal static void Magnifier(Graphics g)
        {

        }

        internal static void NoDoubleBuffer(Graphics g)
        {
        }

        internal static void ApplyCanny(double threshold = 50.0, double thresholdLink = 20.0)
        {
            _threshold = threshold;
            _thresholdLink = thresholdLink;
        }

        internal static void ApplySobel(int xorder = 1, int yorder = 0, int apertureSize = 3)
        {
            _xorder = xorder;
            _yorder = yorder;
            _apertureSize = apertureSize;
        }

        internal static void ApplyLaplacian(int apertureSize = 7)
        {
            _apertureSizeLaplacian = apertureSize;
        }
    }
}
