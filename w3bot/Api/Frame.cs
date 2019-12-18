﻿using CefSharp.OffScreen;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using w3bot.Core.Bot;
using w3bot.Core.Processor;
using w3bot.Script;
using w3bot.Util;

namespace w3bot.Api
{
    public class Frame
    {
        private static Bitmap _browserBitmap;
        private static Point _point;
        private static IProcessor _processor;

        public static Bitmap MainFrame { get { return _processor.Frame; } }

        /// <summary>
        /// Finds all matching pixels by a given color.
        /// </summary>
        /// <param name="pattern"></param>
        public static List<Point> FindAllPixel(PixelSearchPattern pattern)
        {
            List<Point> pointList = new List<Point>();

            Bot.ExeThreadSafe(delegate
            {
                try
                {
                    // fetch browser bitmap
                    _browserBitmap = _processor.Frame;

                    if (_browserBitmap != null)
                    {
                        // locks bitmap in memory
                        BitmapData bitmapData = _browserBitmap.LockBits(new Rectangle(0, 0, _browserBitmap.Width, _browserBitmap.Height), ImageLockMode.ReadWrite, _browserBitmap.PixelFormat);

                        // retrieve color depth in bits each pixel and determine the byte buffer size
                        int bytesPerPixel = Bitmap.GetPixelFormatSize(_browserBitmap.PixelFormat) / 8;
                        int byteCount = bitmapData.Stride * _browserBitmap.Height;
                        byte[] pixels = new byte[byteCount];

                        // get first pointer from pixel and copy values to an unmanaged memory pointer
                        IntPtr ptrFirstPixel = bitmapData.Scan0;
                        Marshal.Copy(ptrFirstPixel, pixels, 0, pixels.Length);

                        int heightInPixels = bitmapData.Height;
                        int widthInBytes = bitmapData.Width * bytesPerPixel;

                        for (int y = 0; y < heightInPixels; y++)
                        {
                            // retrieve current line by y coordinate and line from bitmap
                            int currentLine = y * bitmapData.Stride;
                            for (int x = 0; x < widthInBytes; x = x + bytesPerPixel)
                            {
                                int oldBlue = pixels[currentLine + x];
                                int oldGreen = pixels[currentLine + x + 1];
                                int oldRed = pixels[currentLine + x + 2];

                                // calculate new pixel value
                                pixels[currentLine + x] = (byte)oldBlue;
                                pixels[currentLine + x + 1] = (byte)oldGreen;
                                pixels[currentLine + x + 2] = (byte)oldRed;

                                if (pixels[currentLine + x] == pattern.B && pixels[currentLine + x + 1] == pattern.G && pixels[currentLine + x + 2] == pattern.R)
                                {
                                    _point = new Point(x / bytesPerPixel, y);
                                    pointList.Add(_point);
                                }
                            }
                        }

                        // copy modified bytes back
                        Marshal.Copy(pixels, 0, ptrFirstPixel, pixels.Length);
                        _browserBitmap.UnlockBits(bitmapData);
                    }
                }
                catch (Exception)
                { }
            });

            return pointList;
        }

        /// <summary>
        /// Finds a pixel by a given color.
        /// </summary>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public static Point FindPixel(PixelSearchPattern pattern)
        {
            return (FindAllPixel(pattern).Count > 0) ? FindAllPixel(pattern)[0] : new Point();
        }

        /// <summary>
        /// Finds a pixel by a given color.
        /// </summary>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <param name="tolerance"></param>
        /// <returns></returns>
        public static Point FindPixel(byte r, byte g, byte b, byte tolerance)
        {
            return FindPixel(new PixelSearchPattern(r, g, b, tolerance));
        }

        /// <summary>
        /// Finds an image by a given bitmap. This method use the OpenCV library for fast template matching.
        /// </summary>
        /// <param name="bitmap">The bitmap for template matching.</param>
        /// <param name="tolerance">The threshold of the bitmap. It should set to a decimal value between 0 and 1.0, 1.0 means that the images must be identical with the browser bitmap. Current threshold is 0.8.</param>
        /// <returns>Returns the position of the bitmap in bot window.</returns>
        public static Rectangle FindImage(Bitmap bitmap, double tolerance = 0.8)
        {
            Rectangle rectangle = new Rectangle();

            Bot.ExeThreadSafe(delegate
            {
                _browserBitmap = _processor.Frame;
                Image<Bgr, byte> bImage = new Image<Bgr, byte>(_browserBitmap);
                Image<Bgr, byte> comparedImage = new Image<Bgr, byte>(bitmap);

                double Threshold = tolerance; //set it to a decimal value between 0 and 1.00, 1.00 meaning that the images must be identical

                Image<Gray, float> Matches = bImage.MatchTemplate(comparedImage, TemplateMatchingType.CcoeffNormed);

                for (int y = 0; y < Matches.Data.GetLength(0); y++)
                {
                    for (int x = 0; x < Matches.Data.GetLength(1); x++)
                    {
                        if (Matches.Data[y, x, 0] >= Threshold) //Check if its a valid match
                        {
                            _point = new Point(x, y);
                            rectangle = new Rectangle(_point, new Size(bitmap.Width, bitmap.Height));
                        }
                    }
                }
            });

            return rectangle;
        }

        /// <summary>
        /// Finds text in the bot window. This method use the OpenCV library for text detection.
        /// </summary>
        /// <param name="text">The text for text detection.</param>
        /// <returns>Returns the position by the text.</returns>
        public static Rectangle FindText(string text)
        {
            return new Rectangle();
        }

        internal static void AddConfiguration(IProcessor processor)
        {
            _processor = processor;
        }
    }
}
