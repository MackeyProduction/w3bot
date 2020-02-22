using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using w3bot.Core.Utilities;
using w3bot.Event;

namespace w3bot.Core.Processor
{
    interface IProcessor : IDisposable, IRenderProcessor, ICloneable
    {
        /// <summary>
        /// Activates the processor.
        /// </summary>
        void Activate();

        /// <summary>
        /// Destroys the processor.
        /// </summary>
        void Destroy();

        /// <summary>
        /// Allows input by the processor.
        /// </summary>
        void AllowInput();

        /// <summary>
        /// Blocks incoming input by the processor.
        /// </summary>
        void BlockInput();

        /// <summary>
        /// Sets the focus on the running processor.
        /// </summary>
        void GetFocus();

        /// <summary>
        /// Drops the focus of the running processor.
        /// </summary>
        void DropFocus();

        /// <summary>
        /// Gets the current frame.
        /// </summary>
        Bitmap Frame { get; }
        
        /// <summary>
        /// Gets the current mouse position.
        /// </summary>
        Point MousePos { get; set; }

        /// <summary>
        /// Gets the panel of the processor.
        /// </summary>
        Panel Panel { get; }

        /// <summary>
        /// Validates the processor.
        /// </summary>
        /// <param name="type">The type of the processor.</param>
        /// <returns>Returns an instance of processor.</returns>
        bool IsValidProcessor(ProcessorType type);

        /// <summary>
        /// Mouse event handler.
        /// </summary>
        IMouseEvent MouseHandler { get; set; }
        
        /// <summary>
        /// Keyboard event handler.
        /// </summary>
        IKeyboardEvent KeyboardHandler { get; set; }
        
        /// <summary>
        /// Paint event handler.
        /// </summary>
        IPaintEvent PaintHandler { get; set; }
    }
}
