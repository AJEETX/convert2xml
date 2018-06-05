using Converter.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace Converter.Config
{
    public class UnityConfig
    {
        public static IFileConverter GetConverter()
        {
            var container = new UnityContainer();
            container.RegisterType<IPurchaseOrderGenerator, PurchaseOrderGenerator>();
            container.RegisterType<IPurchaseOrderLineGenerator, PurchaseOrderLineGenerator>();
            container.RegisterType<IFormatData, FormatData>();
            container.RegisterType<IFileWriter, FileWriter>();
            container.RegisterType<IFileReader, FileReader>();
            container.RegisterType<IFileConverter, FileConverter>();
            return container.Resolve<IFileConverter>();
        }
    }
}
