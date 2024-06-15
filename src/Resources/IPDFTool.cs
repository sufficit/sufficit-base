using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Resources
{
    public interface IPDFTool
    {
        byte[] GetPDFFromHTML(string html);
    }
}
