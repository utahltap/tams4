using DotSpatial.Symbology;
using DotSpatial.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using tams4a.Controls;
using tams4a.Forms;

namespace tams4a.Classes
{
    class GenericModule : ProjectModule
    {
        static private readonly string itemSelectionSql = @"";
        private string notes;

        public GenericModule(TamsProject theProject, TabPage controlPage, ToolStripMenuItem[] boundButtons, string mn) : base(theProject, controlPage, boundButtons, itemSelectionSql)
        {
            moduleName = mn;
            notes = "";

        }
    }
}