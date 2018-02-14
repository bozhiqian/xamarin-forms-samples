using System;
using System.Collections.Generic;
using System.Text;

namespace Todo.DependencyService
{
    public interface IFileHelper
    {
        string GetLocalFilePath(string filename);
    }
}
