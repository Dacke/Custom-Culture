using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;

namespace CustomCultureTest
{
    class CustomResourceManager : ResourceManager, IResourceReader
    {
        
        public CustomResourceManager(string baseName, Assembly assembly) : base(baseName, assembly) { }

        public override string GetString(string name)
        {
            var cultureFile = base.GetResourceFileName(Thread.CurrentThread.CurrentUICulture);
            return base.GetString(name);
        }

        public override string GetString(string name, CultureInfo culture)
        {
            var cultureFile = base.GetResourceFileName(culture);
            return base.GetString(name, culture);
        }

        public void Close()
        {
            throw new NotImplementedException();
        }

        public System.Collections.IDictionaryEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
