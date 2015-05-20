using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MEF = System.ComponentModel.Composition.Hosting;

namespace MEFApplication {
    class Program {

        private static MEF.CompositionContainer _container;

        static void Main(string[] args) {

            var assemblyCatalog = new MEF.AssemblyCatalog(typeof(Program).Assembly);
            var directoryCatalog = new MEF.DirectoryCatalog(AppDomain.CurrentDomain.BaseDirectory + "\\Parts", "*.dll");
            var typeCatalog = new MEF.TypeCatalog(typeof(Class6), typeof(Class7));
            var aggregateCatalog = new MEF.AggregateCatalog(assemblyCatalog, directoryCatalog, typeCatalog);

            _container = new MEF.CompositionContainer(aggregateCatalog);

            var exports = _container.GetExports<object>();
            foreach (var exportValue in exports) {
                Console.WriteLine(exportValue.Value.GetType());
            }


            Console.ReadLine();
        }
    }
}
