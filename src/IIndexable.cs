﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit
{
    /// <summary>
    /// Use this interface to track an object with client context and filter properties
    /// </summary>
    public interface IIndexable : IIndex, IIdTitlePair, IContextId
    {     
        string Description { get; }
    }
}
