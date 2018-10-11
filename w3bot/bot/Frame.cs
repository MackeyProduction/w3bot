using CefSharp.OffScreen;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using w3bot.core;
using w3bot.evt;
using w3bot.util;

namespace w3bot.bot
{
    public class Frame
    {
        static ChromiumWebBrowser _chromiumBrowser;
        static BotWindow _botWindow;
        static Bot _bot;

        /// <summary>
        /// Finds a pixel by a given color.
        /// </summary>
        /// <param name="pattern"></param>
        public static Point FindPixel(PixelSearchPattern pattern)
        {
            Point point = new Point();

            Core.ExeThreadSafe(delegate
            {
                Bitmap browserBitmap;
                _chromiumBrowser.ScreenshotAsync().ContinueWith(task =>
                {
                    try
                    {
                        // load browser bitmap
                        browserBitmap = task.Result;

                        if (browserBitmap != null)
                        {
                            BitmapData imageData = browserBitmap.LockBits(new Rectangle(0, 0, browserBitmap.Width, browserBitmap.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

                            byte[] imageBytes = new byte[Math.Abs(imageData.Stride) * browserBitmap.Height];
                            IntPtr scan0 = imageData.Scan0;

                            Marshal.Copy(scan0, imageBytes, 0, imageBytes.Length);

                            byte unmatchingValue = 0;
                            byte matchingValue = 255;
                            int toleranceSquared = pattern.tolerance * pattern.tolerance;

                            for (int y = 0; y < imageData.Width; y++)
                            {
                                int i = y * imageData.Stride;
                                for (int x = 0; x < imageBytes.Length; x += 3)
                                {
                                    int diffR = imageBytes[i + 2] - pattern.R;
                                    int diffG = imageBytes[i + 1] - pattern.G;
                                    int diffB = imageBytes[i] - pattern.B;

                                    int distance = diffR * diffR + diffG * diffG + diffB * diffB;

                                    imageBytes[i] = imageBytes[i + 1] = imageBytes[i + 2] = distance >
                                      toleranceSquared ? unmatchingValue : matchingValue;

                                    point = new Point(x, y);
                                }
                            }

                            Marshal.Copy(imageBytes, 0, scan0, imageBytes.Length);
                            browserBitmap.UnlockBits(imageData);
                        }
                    }
                    catch (Exception)
                    { }
                });
            });

            return point;
        }

        public static Point FindPixel(byte r, byte g, byte b, byte tolerance)
        {
            return FindPixel(new PixelSearchPattern(r, g, b, tolerance));
        }

        public static void FindImage(Bitmap bitmap, PixelSearchPattern pattern)
        {
            
        }

        internal static void AddConfiguration(Bot bot)
        {
            _bot = bot;
            if (_bot.botWindow == null) throw new InvalidOperationException("The Botwindow isn't initialized. Please initialize the botwindow with the Initialize() method.");
            _botWindow = _bot.botWindow;
            _chromiumBrowser = _botWindow._chromiumBrowser;
        }
    }
}
