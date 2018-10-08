using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace MTGTool.Model.System
{
    class FontList : IEnumerable<FontFamily>
    {
       public ICollection<FontFamily> fontList { get; } = Fonts.SystemFontFamilies;

        public IEnumerator<FontFamily> GetEnumerator()
        {
            return fontList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return fontList.GetEnumerator();
        }
    }
}
