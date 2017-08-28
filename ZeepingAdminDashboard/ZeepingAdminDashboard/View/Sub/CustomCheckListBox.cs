using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZeepingAdminDashboard.View.Sub
{
    public class CustomCheckListBox : CheckedListBox
    {
        public delegate Color GetColorDelegate(CustomCheckListBox listbox, DrawItemEventArgs e);
        public delegate Font GetFontDelegate(CustomCheckListBox listbox, DrawItemEventArgs e);

        [Description("Supply a foreground color for each item")]
        public event GetColorDelegate GetForeColor = null;
        [Description("Supply a background color for each item")]
        public event GetColorDelegate GetBackColor = null;
        [Description("Supply a font for each item")]
        public event GetFontDelegate GetFont = null;

        [Description("Set this if you don't like the standard selection appearance")]
        public bool DrawFocusedIndicator { get; set; }

        public override int ItemHeight { get; set; }
        public void OnDrawItemCustom(DrawItemEventArgs e)
        {
            OnDrawItem(e);
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            Color foreColor = (GetForeColor != null) ? GetForeColor(this, e) : e.ForeColor;
            Color backColor = (GetBackColor != null) ? GetBackColor(this, e) : e.BackColor;

            //
            // The CheckListBox is going to ignore the font in the event
            // args and use its own.  So, make its own the one we want it
            // to be.  For this to always work right, we will have to shut
            // down the OnFontChanged method below.
            //
            if (GetFont != null) this.Font = GetFont(this, e);

            //
            // If desired, draw an item focused, but not selected.
            //
            DrawItemState state = (DrawFocusedIndicator)
                ? ((e.State & DrawItemState.Focus) == DrawItemState.Focus)
                    ? DrawItemState.Focus
                    : DrawItemState.None
                : e.State;

            //
            // e.Font is going to be ignored.
            //
            DrawItemEventArgs e2 = new DrawItemEventArgs(e.Graphics,
                e.Font, e.Bounds, e.Index, state, foreColor, backColor);

            base.OnDrawItem(e2);
        }

        protected override void OnFontChanged(EventArgs e)
        {
            if (GetFont == null) base.OnFontChanged(e);
        }
    }
}
